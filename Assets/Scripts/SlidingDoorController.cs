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

    private void Update()
    {
        float leverValNorm = _leverReader.LeverValue;
        _doorTransform.localPosition = (Vector3.Lerp(_closedPos, _openPos, leverValNorm));
    }
}
