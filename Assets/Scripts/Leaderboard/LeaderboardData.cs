using System;

public class LeaderboardData
{
    public string Name;
    public DateTime CompletionTime;

    public LeaderboardData(string name, DateTime time)
    {
        Name = name;
        CompletionTime = time;
    }
}