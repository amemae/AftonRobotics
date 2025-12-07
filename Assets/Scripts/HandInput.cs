using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandInput : MonoBehaviour
{
    private const float GRIP_THRESHOLD = 0.5f;

    [SerializeField]
    private InputActionProperty _gripActionProp;

    public bool IsGripping { get; private set; }
    public event Action<bool> OnGripChanged;

    void Update()
    {
        float gripValue = _gripActionProp.action.ReadValue<float>();
        bool newState = gripValue > GRIP_THRESHOLD;
        
        if (newState != IsGripping)
        {
            IsGripping = newState;
            OnGripChanged?.Invoke(IsGripping);
        }
    }
}
