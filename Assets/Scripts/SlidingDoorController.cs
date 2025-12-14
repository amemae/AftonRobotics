using UnityEngine;

public class SlidingDoorController : MonoBehaviour
{
    [SerializeField]
    private LeverReader _leverReader;
    [SerializeField]
    private Transform _doorTransform;
    [SerializeField]
    private Vector3 _openOffset;

    private Vector3 _openPos;
    private Vector3 _closedPos;

    private void Start()
    {
        _closedPos = _doorTransform.localPosition;
        _openPos = _closedPos + _openOffset;
    }

    private void OnEnable()
    {
        _leverReader.OnEndpointChanged += HandleEndpointChanged;
    }

    private void OnDisable()
    {
        _leverReader.OnEndpointChanged -= HandleEndpointChanged;
    }

    private void HandleEndpointChanged(LeverReader.EndpointState endpointState)
    {
        switch (endpointState)
        {
            case LeverReader.EndpointState.AtMin:
                CloseDoor();
                break;
            case LeverReader.EndpointState.AtMax:
                OpenDoor();
                break;
        }
    }

    private void CloseDoor()
    {
        _doorTransform.localPosition = _closedPos;
    }

    private void OpenDoor()
    {
        _doorTransform.localPosition = _openPos;
    }
}
