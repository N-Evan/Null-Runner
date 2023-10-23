using System;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public bool IsTimerRunning;

    private float _timer;

    public TextMeshProUGUI TimerUiElement;

    private void Update()
    {
        if (IsTimerRunning)
        {
            _timer += Time.deltaTime;
            TimerUiElement.text = GetCurrentTime();
        }
    }

    [ContextMenu("Start Timer")]
    public void StartTimer()
    {
        SetTimerState(true);
    }

    [ContextMenu("Pause Timer")]
    public void PauseTimer()
    {
        SetTimerState(false);
    }

    public string GetCurrentTime()
    {
        TimeSpan currentTime = TimeSpan.FromSeconds(_timer);
        return currentTime.ToString(@"hh\:mm\:ss");
    }

    private void SetTimerState(bool activateTimer)
    {
        IsTimerRunning = activateTimer;
    }

    public void ResetTimer()
    {
        SetTimerState(false);
        _timer = 0f;
    }
}