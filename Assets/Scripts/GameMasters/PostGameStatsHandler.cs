using TMPro;
using UnityEngine;

public class PostGameStatsHandler : MonoBehaviour
{
    public TMP_InputField NameInputField;
    public TextMeshProUGUI CurrentTimer;

    private void Awake()
    {
        NameInputField.text = "";
        NameInputField.characterLimit = 3;
        SetCurrentTimer();
    }

    private void SetCurrentTimer()
    {
        CurrentTimer.text = GameMaster.Instance.GameTimeMaster.GetCurrentTimeInString();
    }

    public void OnEntrySubmission()
    {
        LeaderboardController.Instance.AddEntry(NameInputField.text, GameMaster.Instance.GameTimeMaster.DateTimeGetTimerAsDateTime());
    }
}