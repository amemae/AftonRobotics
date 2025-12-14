using System;
using UnityEngine;

public class LeverReader : MonoBehaviour
{
    public enum EndpointState { AtMin, AtMax, None }
    private const float ENDPOINT_THRESHOLD = 0.01f;

    [SerializeField]
    private HingeJoint _hinge;

    private float _minAngle;
    private float _maxAngle;

    public EndpointState LastEndpointReached { get; private set; } = EndpointState.None;
    public event Action<EndpointState> OnEndpointChanged;

    public float LeverValue
    {
        get
        {
            return Mathf.InverseLerp(_minAngle, _maxAngle, _hinge.angle);
        }
    }

    private void Awake()
    {
        _minAngle = _hinge.limits.min;
        _maxAngle = _hinge.limits.max;
    }

    private void Update()
    {
        EndpointState newState = CalcEndpointState(LeverValue);

        if (newState != EndpointState.None && newState != LastEndpointReached)
        {
            LastEndpointReached = newState;
            OnEndpointChanged?.Invoke(newState);
        }
    }

    private EndpointState CalcEndpointState(float leverVal)
    {
        if (leverVal <= ENDPOINT_THRESHOLD)
        {
            return EndpointState.AtMin;
        }
        else if (leverVal >= 1f - ENDPOINT_THRESHOLD)
        {
            return EndpointState.AtMax;
        }

        return EndpointState.None;
    }
}
