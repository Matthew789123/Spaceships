using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderboardPresenter
{
    private LeaderboardModel leaderboardModel;
    private LeaderboardView view;
    private bool changed=false;

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

    public void CheckScore(int score)
    {
        Load();
        for (int i = 0; i < Count() - 1; i++)
        {
            if (score >= GetEntry(i).score)
            {
                changed = true;
                PlayerPrefs.SetInt("score", score);
                PlayerPrefs.SetInt("position", i);
                
                break;
            }
        }
        if(changed==true)
        {
            SceneManager.LoadScene(2);
        }
        else
            SceneManager.LoadScene(0);
    }

    public void addEntry()
    {
        Load();
        LeaderboardModel.Entry entry = new LeaderboardModel.Entry { score = PlayerPrefs.GetInt("score"), name = PlayerPrefs.GetString("nick") };
        leaderboardModel.scores.entryList.Insert(PlayerPrefs.GetInt("position"), entry);
        leaderboardModel.scores.entryList.RemoveAt(Count() - 1);
        Save(leaderboardModel.scores);
    }

}
