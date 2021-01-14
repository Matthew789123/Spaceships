using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NewHighScore : MonoBehaviour
{
    private string name;
    private GameObject input;
    private GameObject points;
    public TextMeshProUGUI pointsText;
    private InputField inputText;

    public void toMenu()
    {
        PlayerPrefs.SetString("nick", inputText.text);
        addEntry();
        SceneManager.LoadScene(0);
    }

    private void Awake()
    {
        input = GameObject.Find("InputField");
        inputText = input.GetComponent<InputField>();
        points = GameObject.Find("Points");
        pointsText = points.GetComponent<TextMeshProUGUI>();
        pointsText.text = PlayerPrefs.GetInt("score").ToString();
       
    }


    private void addEntry()
    {
        LeaderboardView view = new LeaderboardView();
        view.addEntry();
    }
}
