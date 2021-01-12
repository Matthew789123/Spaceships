using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LeaderboardModel
{
    public class Leaderboard
    {
        public List<Entry> entryList;
    }

    [System.Serializable]
    public class Entry
    {
        public int score;
        public string name;
    }


    public Leaderboard scores;

    public LeaderboardModel()
    {
        scores = new Leaderboard();
        scores.entryList = new List<Entry>();
    }

    

}