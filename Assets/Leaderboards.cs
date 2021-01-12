using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboards : MonoBehaviour
{
    private Transform template;
    private Transform container;
    private List<Transform> transformEntryList;
    private void Awake()
    {
        container = transform.Find("Table");
        template = container.Find("Template");

        template.gameObject.SetActive(false);

        string jsonString = PlayerPrefs.GetString("leaderboards");
        Leaderboard scores = JsonUtility.FromJson<Leaderboard>(jsonString);

        for(int i=0; i < scores.entryList.Count; i++)
        {
            for(int j=i+1; j<scores.entryList.Count; j++)
            {
                if(scores.entryList[j].score > scores.entryList[i].score)
                {
                    Entry temp = scores.entryList[i];
                    scores.entryList[i] = scores.entryList[j];
                    scores.entryList[j] = temp;
                }
            }
        }

        transformEntryList = new List<Transform>();
        foreach(Entry e in scores.entryList )
        {
            CreateEntryTransform(e, container, transformEntryList);
        } 
        
    }

    private void CreateEntryTransform(Entry entry, Transform container,List<Transform> transformList)
    {
        float templateHight = 40f;
        Transform entryTransform = Instantiate(template, container);
        RectTransform rectTransform = entryTransform.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0, -templateHight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int score = entry.score;
        string name = entry.name;
        entryTransform.Find("Nick").GetComponent<Text>().text = name;
        entryTransform.Find("Score").GetComponent<Text>().text = score.ToString();


        transformList.Add(entryTransform);
    }

    

    private void AddEntry(int score, string name)
    {
        Entry entry = new Entry { score = score, name = name };
        string jsonString = PlayerPrefs.GetString("leaderboards");
        Leaderboard scores = JsonUtility.FromJson<Leaderboard>(jsonString);
        scores.entryList.Add(entry);

        string json = JsonUtility.ToJson(scores);
        PlayerPrefs.SetString("leaderboards", json);
        PlayerPrefs.Save();

    }


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
}

