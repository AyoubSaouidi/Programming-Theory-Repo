using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInteractable : MonoBehaviour, IInteractable
{
    #region IInteractable Properties Implementation
    [Header("Interactibility Settings")]
    // Fields
    [SerializeField]
    protected bool _isInteractable = true;

    // Properties
    public bool IsInteractable => _isInteractable;
    #endregion

    #region IInteractable Methods Implementation
    public virtual void Interact()
    {
        Debug.Log($"> Interacted: {gameObject.name}");

        if (_isInteractable)
            OnInteract();
    }

    // ABSTRACTION
    public virtual void OnInteract()
    {
        Debug.Log($"> On Interct: {gameObject.name}");
    }
    #endregion
}
