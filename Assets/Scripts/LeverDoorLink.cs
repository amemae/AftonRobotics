using UnityEngine;

public class LeverDoorLink : MonoBehaviour
{
    [SerializeField]
    private SlidingDoorController _sDoor;
    [SerializeField]
    private LeverReader _leverReader;


    void Awake()
    {
        if (_sDoor == null)
        {
            Debug.LogWarning("No door attached", this);
            enabled = false;
            return;
        }
        if (_leverReader == null)
        {
            Debug.LogWarning("No lever attached", this);
            enabled = false;
            return;
        }

        Debug.Log("Link established between " + _sDoor
            .gameObject.name+ " and " +  _leverReader.gameObject.name);
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
                _sDoor.CloseDoor();
                break;
            case LeverReader.EndpointState.AtMax:
                _sDoor.OpenDoor();
                break;
        }
    }
}
