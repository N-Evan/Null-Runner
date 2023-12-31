﻿using System.Collections.Generic;
using UnityEngine;

public class LeaderboardUiController : MonoBehaviour
{
    public LeaderboardEntry LeaderboardEntryPrefab;
    public Transform ContentParent;
    private readonly int _entriesPerPage = 20;

    private List<LeaderboardData> _leaderboardEntries;
    private int _currentPage = 1;

    private void Start()
    {
        LoadLeaderboardData();
        DisplayLeaderboard(_currentPage);
    }

    private void LoadLeaderboardData()
    {
        // You should have a reference to the LeaderboardManager or load the data directly here.
        // Replace this with how you access your leaderboard data.
        _leaderboardEntries = LeaderboardController.Instance.GetLeaderboard();
    }

    public void DisplayLeaderboard(int page)
    {
        ClearLeaderboardEntries();
        LoadLeaderboardData();
        int startIndex = (page - 1) * _entriesPerPage;
        int endIndex = Mathf.Min(startIndex + _entriesPerPage, _leaderboardEntries.Count);

        for (int i = startIndex; i < endIndex; i++)
        {
            LeaderboardData entry = _leaderboardEntries[i];
            LeaderboardEntry entryPrefab = Instantiate(LeaderboardEntryPrefab, ContentParent);
            entryPrefab.SetupEntry(entry, i + 1);
        }
    }

    private void ClearLeaderboardEntries()
    {
        foreach (Transform child in ContentParent)
        {
            Destroy(child.gameObject);
        }
    }

    public void NextPage()
    {
        if ((_currentPage * _entriesPerPage) < _leaderboardEntries.Count)
        {
            _currentPage++;
            DisplayLeaderboard(_currentPage);
        }
    }

    public void PreviousPage()
    {
        if (_currentPage > 1)
        {
            _currentPage--;
            DisplayLeaderboard(_currentPage);
        }
    }
}