using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class LeaderboardController : MonoBehaviour
{
    private static LeaderboardController _instance;

    public static LeaderboardController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<LeaderboardController>();
                if (_instance == null)
                {
                    GameObject leaderboardController = new GameObject("Leaderboard Controller");
                    _instance = leaderboardController.AddComponent<LeaderboardController>();
                    return _instance;
                }
            }
            return _instance;
        }
    }

    private const string _leaderboardFileName = "leaderboard.json";
    private List<LeaderboardData> _leaderboardEntries;

    private void Start()
    {
        _leaderboardEntries = LoadLeaderboard();
    }

    public void AddEntry(string name, DateTime completionTime)
    {
        LeaderboardData newEntry = new LeaderboardData(name, completionTime);
        _leaderboardEntries.Add(newEntry);
        _leaderboardEntries = _leaderboardEntries.OrderBy(entry => entry.CompletionTime).ToList();
        SaveLeaderboard(_leaderboardEntries);
    }

    public List<LeaderboardData> GetLeaderboard()
    {
        return _leaderboardEntries;
    }

    private List<LeaderboardData> LoadLeaderboard()
    {
        List<LeaderboardData> entries = new List<LeaderboardData>();
        string path = Path.Combine(Application.persistentDataPath, _leaderboardFileName);

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            entries = JsonUtility.FromJson<List<LeaderboardData>>(json);
        }

        return entries;
    }

    private void SaveLeaderboard(List<LeaderboardData> entries)
    {
        string json = JsonUtility.ToJson(entries);
        string path = Path.Combine(Application.persistentDataPath, _leaderboardFileName);
        File.WriteAllText(path, json);
    }
}