using UnityEngine;

public class SlidingDoorController : MonoBehaviour
{
    [SerializeField]
    private Transform _doorTransform;
    [SerializeField]
    private Vector3 _openOffset;
    [SerializeField]
    private float _moveDur = 0.5f;

    private Vector3 _openPos;
    private Vector3 _closedPos;
    private Vector3 _tarPos;
    private float _moveElapsed;
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

    public void CloseDoor()
    {
        _isClosed = true;
        _doorTransform.localPosition = _closedPos;
    }

    public void OpenDoor()
    {
        _isClosed = false;
        _doorTransform.localPosition = _openPos;
    }
}
