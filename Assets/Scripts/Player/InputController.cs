using Unity.VisualScripting;
using UnityEngine;

public class InputController : MonoBehaviour
{
    #region Keys States
    // Fields
    private bool _isUpPressed = false;
    private bool _isRightPressed = false;
    private bool _isBottomPressed = false;
    private bool _isLeftPressed = false;
    private bool _isInteractKeyPressed = false;

    // Properties
    public bool IsUpPressed => _isUpPressed;
    public bool IsRightPressed => _isRightPressed;
    public bool IsBottomPressed => _isBottomPressed;
    public bool IsLeftPressed => _isLeftPressed;
    public bool IsInteractKeyPressed => _isInteractKeyPressed;
    #endregion

    #region Lifecycle
    private void Update()
    {
        HandleInput();
    }
    #endregion

    #region Custom Methods
    public void HandleInput()
    {
        _isUpPressed = Input.GetKey(KeyCode.W);
        _isRightPressed = Input.GetKey(KeyCode.D);
        _isBottomPressed = Input.GetKey(KeyCode.S);
        _isLeftPressed = Input.GetKey(KeyCode.A);
        _isInteractKeyPressed = Input.GetKeyDown(KeyCode.E);
    }
    #endregion
}
