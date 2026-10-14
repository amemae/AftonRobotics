using UnityEngine;

public class AnimatronicController : MonoBehaviour
{
    [SerializeField]
    private GameObject _animatronicVisual;

    private int _AILevel = 20;
    //In seconds
    private float _actionInterval = 3f;
    private bool _isPresent = false;


    private void Start()
    {
    }
}
