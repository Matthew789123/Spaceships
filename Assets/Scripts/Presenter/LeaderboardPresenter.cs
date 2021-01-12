using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LeaderboardPresenter
{
    public LeaderboardModel leaderboardModel;
    public LeaderboardView view;

    public LeaderboardPresenter(LeaderboardView view)
    {
        leaderboardModel = new LeaderboardModel();
        this.view = view;
    }

    public void Save(LeaderboardModel.Leaderboard leaderboard)
    {
        string json = JsonUtility.ToJson(leaderboard);
        File.WriteAllText(Application.dataPath + "/save.txt", json);
    }

    public void Load()
    {
        

        if (File.Exists(Application.dataPath + "/save.txt"))
        {
            string json = File.ReadAllText(Application.dataPath + "/save.txt");
            leaderboardModel.scores = JsonUtility.FromJson<LeaderboardModel.Leaderboard>(json);
        }
        
        else
        {
            for(int i = 0; i < 7; i++)
            {
                LeaderboardModel.Entry entry = new LeaderboardModel.Entry { name = "Player", score = (9 - i + 1) * 100 }; 
                leaderboardModel.scores.entryList.Add(entry);
            }
            
            Save(leaderboardModel.scores);
        }
    }

    public int Count()
    {
        return leaderboardModel.scores.entryList.Count;
    }

    public LeaderboardModel.Entry GetEntry(int i)
    {
        return leaderboardModel.scores.entryList[i];
    }

    public List<LeaderboardModel.Entry> GetEntries()
    {
        return leaderboardModel.scores.entryList;
    }

}
