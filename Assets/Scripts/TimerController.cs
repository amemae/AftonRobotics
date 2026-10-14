using TMPro;
using UnityEngine;

//TODO: Move timing logic to outside TimerController and feed events to the TimerController for display
public class TimerController : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro _tmp;
    [SerializeField]
    private GameTimeController _gtc;

    private int _startingSeconds;
    private int _secondsRemaining;
    private float _accumulatedDeltaTime;

    private void Start()
    {
        _startingSeconds = _gtc.TotalLevelTime;
        UpdateDisplay(_startingSeconds);
    }

    private void OnEnable()
    {
        _gtc.OnSecondChanged += UpdateDisplay;
    }

    private void OnDisable()
    {
        _gtc.OnSecondChanged -= UpdateDisplay;
    }

    private void UpdateDisplay(int secondsIntoLevel)
    {
        int secondsRemaining = _gtc.TotalLevelTime - secondsIntoLevel;
        _tmp.text = secondsRemaining.ToString("00");
    }
}
