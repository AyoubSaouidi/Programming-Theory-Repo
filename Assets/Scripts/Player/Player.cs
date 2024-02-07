using UnityEngine;

public class Player : MonoBehaviour
{
    #region Controllers References
    private InputController _inputController;
    #endregion

    #region Movement Members
    [Header("Movement Settings")]
    // Fields
    [SerializeField]
    private float _speed = 5f;
    private Vector3 _movementDirection = Vector3.zero;

    // Properties
    public float Speed => _speed;
    public Vector3 MovementDirection => _movementDirection;
    #endregion

    #region Lifecycle
    private void Awake()
    {
        _inputController = gameObject.GetComponent<InputController>();
    }

    private void Start()
    {
        //    _speed = 5f;
        //    _movementDirection = Vector3.zero;
    }

    void Update()
    {
        HandleMovement();
    }
    #endregion

    #region Custom Methods
    // Sets player movement direction based on player input retrieved from InputCotroller instance
    private void SetMovementDirection()
    {
        // Forward
        if (_inputController.IsUpPressed)
        {
            _movementDirection.z = 1f;
        }
        // Backward
        else if (_inputController.IsBottomPressed)
        {
            _movementDirection.z = -1f;
        }
        // No movement on Z axis
        else
        {
            _movementDirection.z = 0f;
        }

        // Right
        if (_inputController.IsRightPressed)
        {
            _movementDirection.x = 1;
        }
        // Left
        else if (_inputController.IsLeftPressed)
        {
            _movementDirection.x = -1;
        }
        // No movement on X axis
        else
        {
            _movementDirection.x = 0;
        }
    }

    // Move player in movement direction with player speed while rotating player towards movement direction
    private void Move()
    {
        if (_movementDirection == Vector3.zero)
            return;
        gameObject.transform.rotation = Quaternion.LookRotation(_movementDirection);
        gameObject.transform.Translate(_movementDirection * _speed * Time.deltaTime, Space.World);
    }

    private void HandleMovement()
    {
        SetMovementDirection();
        Move();
    }
    #endregion
}
