using UnityEngine;

public class SlidingDoorController : MonoBehaviour
{
    [SerializeField]
    private Transform _doorTransform;
    [SerializeField]
    private Vector3 _openOffset;
    [SerializeField]
    private float _moveTime = 0.5f;

    private Vector3 _openPos;
    private Vector3 _closedPos;
    private float _moveTimeElapsed;
    private Vector3 _moveStartPos;
    private Vector3 _tarPos;
    private bool _isMoving = false;
    private bool _isClosed;

    public bool IsClosed
    {
        get { return _isClosed; } 
    }

    private void Start()
    {
        _isClosed = true;
        _closedPos = _doorTransform.localPosition;
        _openPos = _closedPos + _openOffset;
    }

    private void Update()
    {
        MoveDoor();
    }

    public void CloseDoor()
    {
        _tarPos = _closedPos;
        SetupMoveDoor();
    }

    public void OpenDoor()
    {
        _tarPos = _openPos;
        _isClosed = false;
        SetupMoveDoor();
    }

    private void SetupMoveDoor()
    {
        _moveStartPos = _doorTransform.localPosition;
        _moveTimeElapsed = 0f;
        _isMoving = true;
    }

    private void MoveDoor()
    {
        if (_isMoving)
        {
            _moveTimeElapsed += Time.deltaTime;
            float t = Mathf.Clamp01(_moveTimeElapsed / _moveTime);

            _doorTransform.localPosition = Vector3.Lerp(_moveStartPos, _tarPos, t);

            //If door has reached target
            if (t >= 1f)
            {
                _isMoving = false;

                if (_tarPos == _closedPos)
                {
                    _isClosed = true;
                }
            }
        }
    }
}
