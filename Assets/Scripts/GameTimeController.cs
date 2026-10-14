using System;
using UnityEngine;

public class GameTimeController : MonoBehaviour
{
    private int _secondsIntoLevel;
    private float _accumulatedDeltaTime;

    //TODO: Update to reference level rather than magic number
    public int TotalLevelTime { get { return 60; } }

    public event Action<int> OnSecondChanged;

    private void Update()
    {
        if (_secondsIntoLevel >= TotalLevelTime)
        {
            //TODO: Display win screen
            return;
        }

        _accumulatedDeltaTime += Time.deltaTime;

        if (_accumulatedDeltaTime >= 1f)
        {
            _accumulatedDeltaTime -= 1f;
            ++_secondsIntoLevel;

            OnSecondChanged?.Invoke(_secondsIntoLevel);
        }
    }
}
