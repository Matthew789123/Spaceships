using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuView : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadScene("spaceships");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
