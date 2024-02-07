using UnityEngine;

public class InteractionController : MonoBehaviour
{
    #region Controllers References
    private InputController _inputController;
    #endregion

    #region Interaction Setting
    // Fields
    [SerializeField]
    private float _interactionRadius = 1f;

    [SerializeField]
    private Transform _interactionPoint;

    [SerializeField]
    private FloatingUI _interactionBubbleFloatingUI;

    // Properties
    public float InteractionRadius => _interactionRadius;
    public Transform InteractionPoint => _interactionPoint;
    #endregion

    #region Lifecycle
    private void Awake()
    {
        _inputController = gameObject.GetComponent<InputController>();
    }

    private void Update()
    {
        HandleInteraction();
    }
    #endregion

    #region Custom Methods
    // Handle player intercation with interactable object on interaction key pressed
    private void HandleInteraction()
    {
        if (TryGetOverlappedInteractable(out BaseInteractable target))
        {
            if (target.IsInteractable)
            {
                SetInteractionBubbleTarget(target.gameObject.transform);
                ShowInteractionBubble();
                if (_inputController.IsInteractKeyPressed)
                {
                    target.Interact();
                    HideInteractionBubble();
                    SetInteractionBubbleTarget(null);
                }
            }
        }
        else
        {
            HideInteractionBubble();
            SetInteractionBubbleTarget(null);
        }
    }

    // Try get the first intercatable object found in overlapped collider
    private bool TryGetOverlappedInteractable(out BaseInteractable target)
    {
        // Get hits colliders overlapped with the sphere of the interaction range
        Collider[] hits = Physics.OverlapSphere(_interactionPoint.position, _interactionRadius);
        // Search for interactable target in colliders
        foreach (Collider hit in hits)
        {
            if (hit.gameObject.TryGetComponent<BaseInteractable>(out BaseInteractable interactable))
            {
                Debug.Log($"> Detected Interactable: {interactable.gameObject.name}");
                target = interactable;
                return true;
            }
        }
        target = null;
        return false;
    }

    private void ShowInteractionBubble()
    {
        _interactionBubbleFloatingUI.gameObject.SetActive(true);
    }

    private void HideInteractionBubble()
    {
        _interactionBubbleFloatingUI.gameObject.SetActive(false);
    }

    private void SetInteractionBubbleTarget(Transform target)
    {
        _interactionBubbleFloatingUI.SetTarget(target);
    }
    #endregion

    #region Gismos Drawing Methods
    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_interactionPoint.transform.position, _interactionRadius);
    }
    #endregion
}
