using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.UI;

public class LeaderboardView : MonoBehaviour
{
    private LeaderboardPresenter leaderboardPresenter;
    private Transform template;
    private Transform container;
    private List<Transform> transformEntryList;


    private void Awake()
    {
        leaderboardPresenter = new LeaderboardPresenter(this);
        container = transform.Find("Table");
        template = container.Find("Template");

        template.gameObject.SetActive(false);

        leaderboardPresenter.Load();

        transformEntryList = new List<Transform>();
        foreach (LeaderboardModel.Entry e in leaderboardPresenter.GetEntries())
        {
            CreateEntryTransform(e, container, transformEntryList);
        }

    }

    private void CreateEntryTransform(LeaderboardModel.Entry entry, Transform container, List<Transform> transformList)
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

    public void CheckScore(int score)
    {
        leaderboardPresenter = new LeaderboardPresenter(this);
        leaderboardPresenter.CheckScore(score);
    }
    public void addEntry()
    {
        leaderboardPresenter = new LeaderboardPresenter(this);
        leaderboardPresenter.addEntry();
    }
}
