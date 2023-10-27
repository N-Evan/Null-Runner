using System;
using TMPro;
using UnityEngine;

public class LeaderboardEntry : MonoBehaviour
{
    public TextMeshProUGUI Position;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI CompletionTime;

    public void SetupEntry(LeaderboardData data, int position)
    {
        Position.text = position.ToString();
        Name.text = data.Name;
        CompletionTime.text = data.CompletionTime.ToString(@"hh\:mm\:ss");
    }
}