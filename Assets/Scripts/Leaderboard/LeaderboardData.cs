using System;

[Serializable]
public class LeaderboardData
{
    public string Name;
    public TimeSpan CompletionTime;

    public LeaderboardData(string name, TimeSpan time)
    {
        Name = name;
        CompletionTime = time;
    }
}