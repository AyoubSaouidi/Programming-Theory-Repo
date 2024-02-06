using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FormHandler : MonoBehaviour
{
    [Header("The button we disable/enable depending on name input validation")]
    [SerializeField]
    private Button _startButton;

    [Header("The error message Text component")]
    [SerializeField]
    private TMP_Text _errorMessageText;

    [Header("Name of the scene to load")]
    [SerializeField]
    private string _sceneName;

    private string _name;

    void Start()
    {
        this._startButton.interactable = false;
        _errorMessageText.gameObject.SetActive(false);
        _errorMessageText.text = "";
    }

    public void OnNameChanged(string value)
    {
        this._name = value;

        // Empty name value case
        if (String.IsNullOrEmpty(value))
        {
            _errorMessageText.text = "Name should not be empty";
            _errorMessageText.gameObject.SetActive(true);
            this._startButton.interactable = false;
            return;
        }

        _errorMessageText.gameObject.SetActive(false);
        _errorMessageText.text = "";
        this._startButton.interactable = true;
    }

    public void OnStartButtonClick()
    {
        this.GoToScene(_sceneName);
    }

    public void GoToScene(string sceneName)
    {
        if (String.IsNullOrEmpty(sceneName))
            return;

        SceneManager.LoadScene(sceneName);
    }
}
