using UnityEngine;

public class LeverReader : MonoBehaviour
{
    public enum Axis { X, Y, Z };


    [SerializeField]
    private HingeJoint _hinge;

    [SerializeField]
    private Axis _rotationAxis;

    private float _minAngle;
    private float _maxAngle;

    private void Awake()
    {
        _minAngle = _hinge.limits.min;
        _maxAngle = _hinge.limits.max;
    }

    public float LeverValue
    {
        get
        {
            float angle = CalcLeverVal();

            if (angle > 180f)
            {
                angle -= 360f;
            }
            return Mathf.InverseLerp(_minAngle, _maxAngle, angle);
        }
    }

    private float CalcLeverVal()
    {
        float val = 0f;
        Vector3 angles = transform.localEulerAngles;

        //Base the value of rotation on the given _rotationAxis
        switch (_rotationAxis)
        {
            case Axis.X:
                val = angles.x;
                break;
            case Axis.Y:
                val = angles.y;
                break;
            case Axis.Z:
                val = angles.z;
                break;
        }

        return val;
    }
}
