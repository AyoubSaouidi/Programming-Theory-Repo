using UnityEngine;

// INHERITANCE
public class Door : BaseInteractable
{
    #region Door Rotation
    // Fields
    [SerializeField]
    private float _rotationSpeed;
    private Quaternion _towardsRotation;

    #endregion

    #region Door State
    // Fields
    [SerializeField]
    private bool _isOpen = false;
    private bool _isOpenning = false;
    private bool _isClosing = false;

    // Properties
    // ENCAPSULATION
    public bool IsOpen => IsOpen;
    #endregion

    #region Lifecycle
    void Update()
    {
        if (_isOpenning)
        {
            Openning();
        }
        if (_isClosing)
        {
            Closing();
        }
    }
    #endregion

    #region Interactable Methods
    // POLYMORPHISM
    public override void OnInteract()
    {
        Debug.Log($"> Door Interacted");

        if (_isOpenning || _isClosing)
            return;

        _isInteractable = false;

        if (!_isOpen)
            Open();
        else
            Close();
    }
    #endregion

    #region Custom Methods
    public void Open()
    {
        _towardsRotation = Quaternion.Euler(
            transform.rotation.x,
            transform.rotation.y + 90,
            transform.rotation.z
        );
        _isOpenning = true;
    }

    private void Openning()
    {
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            _towardsRotation,
            _rotationSpeed * Time.deltaTime
        );
        if (_towardsRotation == transform.rotation)
        {
            _isOpenning = false;
            _isOpen = true;
            _isInteractable = true;
        }
    }

    public void Close()
    {
        _towardsRotation = Quaternion.Euler(
            transform.rotation.x,
            transform.rotation.y,
            transform.rotation.z
        );
        _isClosing = true;
    }

    private void Closing()
    {
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            _towardsRotation,
            _rotationSpeed * Time.deltaTime
        );

        if (_towardsRotation == transform.rotation)
        {
            _isClosing = false;
            _isOpen = false;
            _isInteractable = true;
        }
    }
    #endregion
}
