using UnityEngine;

public class HandVisual : MonoBehaviour
{
    [SerializeField]
    public Renderer handRenderer;
    [SerializeField]
    private HandInput handInput;

    private Color notGrippedColor = Color.blue;
    private Color grippedColor = Color.red;

    private void OnEnable()
    {
        handInput.OnGripChanged += HandleGripChanged;
    }

    private void OnDisable()
    {
        handInput.OnGripChanged -= HandleGripChanged;
    }

    private void HandleGripChanged(bool isGripping)
    {
        GetComponent<Renderer>().material.color = isGripping ? grippedColor : notGrippedColor;
    }
}
