using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuView : MonoBehaviour
{
   public void PlayGame()
    {
        
        if (PlayerPrefs.GetString("leaderboards") == null)
        {

        }
        SceneManager.LoadScene("spaceships");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
