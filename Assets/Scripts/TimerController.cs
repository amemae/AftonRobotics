using TMPro;
using UnityEngine;

//TODO: Move timing logic to outside TimerController and feed events to the TimerController for display
public class TimerController : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro _tmp;

    private int _startingSeconds = 60;
    private int _secondsRemaining;
    private float _accumulatedDeltaTime;

    private void Start()
    {
        _secondsRemaining = _startingSeconds;
        UpdateTimerText();
    }

    private void Update()
    {
        if (_secondsRemaining <= 0) return;


        _accumulatedDeltaTime += Time.deltaTime;

        if (_accumulatedDeltaTime >= 1f)
        {
            _accumulatedDeltaTime -= 1f;
            --_secondsRemaining;

            if (_secondsRemaining < 0)
            {
                _secondsRemaining = 0;
            }
            UpdateTimerText();
        }
    }

    private void UpdateTimerText()
    {
        _tmp.text = _secondsRemaining.ToString("00");
    }
}
