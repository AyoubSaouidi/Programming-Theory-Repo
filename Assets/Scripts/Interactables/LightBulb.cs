using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public enum LightState
{
    ON,
    OFF
}

[Serializable]
public class Light
{
    public LightState state = LightState.OFF;
    public Material material;
}

public class LightBulb : BaseInteractable
{
    #region Light State
    // Fields
    private LightState _state = LightState.OFF;
    private GameObject _lightBulb;

    [SerializeField]
    private List<Light> _lights;
    #endregion

    #region Lifecycle
    void Awake()
    {
        _lightBulb = gameObject.transform.GetChild(0).gameObject;
    }
    #endregion

    #region Interactable Methods
    // POLYMORPHISM
    public override void OnInteract()
    {
        Debug.Log($"> Light Bulb Interacted");

        Toggle();
    }
    #endregion

    #region Custom Methods
    // POLYMORPHISM
    private void Toggle()
    {
        Debug.Log($"> Light Bulb Interacted");

        Light oppositeLight = _lights.Find(light => light.state != _state);
        if (oppositeLight == null)
            return;

        _state = oppositeLight.state;

        _lightBulb.GetComponent<MeshRenderer>().material = oppositeLight.material;
    }
    #endregion
}
