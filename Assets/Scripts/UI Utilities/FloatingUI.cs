using UnityEngine;

public class FloatingUI : MonoBehaviour
{
    #region References
    // Fields
    private Camera _mainCamera;
    private Transform _target = null;

    [SerializeField]
    private Vector3 _offset;
    #endregion

    #region LifeCycle
    void Awake()
    {
        _mainCamera = Camera.main;
        gameObject.SetActive(false);
    }

    void Update()
    {
        FollowTarget();
    }
    #endregion

    #region Custom Methods
    private void FollowTarget()
    {
        if (_target == null)
            return;

        transform.rotation = Quaternion.LookRotation(
            transform.position - _mainCamera.transform.position
        );
        transform.position = _target.position + _offset;
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
    #endregion
}
