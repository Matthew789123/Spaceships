using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerView : MonoBehaviour
{
    private SpawnerPresenter spawnerPresenter;
    private System.Random rnd;
    public UnityEngine.UI.Text scoreText;
    private float horzExtent;

    // Start is called before the first frame update
    void Start()
    {
        spawnerPresenter = new SpawnerPresenter(this);
        rnd = new System.Random();
        float vertExtent = Camera.main.GetComponent<Camera>().orthographicSize;
        horzExtent = vertExtent * Screen.width / Screen.height;
        RectTransform transform = scoreText.GetComponent<RectTransform>();
        transform.position = new Vector3(-horzExtent + 1.5f, vertExtent - 0.5f);
    }

    private void FixedUpdate()
    {
        spawnerPresenter.addEnemy();
    }

    public void addEnemyStage1()
    {
        GameObject enemy=null;
        EnemyView ev = null;
        int i = rnd.Next(100);
        if (i < 80)
        {
            enemy = Instantiate(GameObject.Find("EnemyWeak"), new Vector3(horzExtent + 1, rnd.Next(-4, 4), 0), Quaternion.Euler(0, 0, 90));
            ev = enemy.AddComponent<EnemyView>();
            ev.type = 0;
        }
        else if (i >= 80)
        {
            enemy = Instantiate(GameObject.Find("EnemyMedium"), new Vector3(horzExtent + 1, rnd.Next(-4, 4), 0), Quaternion.Euler(0, 0, 90));
            ev = enemy.AddComponent<EnemyView>();
            ev.type = 1;
        }
    }
    
    public void addEnemyStage2()
    {
        GameObject enemy = null;
        EnemyView ev = null;
        int i = rnd.Next(100);
        if (i < 50)
        {
            enemy = Instantiate(GameObject.Find("EnemyWeak"), new Vector3(horzExtent + 1, rnd.Next(-4, 4), 0), Quaternion.Euler(0, 0, 90));
            ev = enemy.AddComponent<EnemyView>();
            ev.type = 0;
        }
        else if (i >= 50 && i < 85)
        {
            enemy = Instantiate(GameObject.Find("EnemyMedium"), new Vector3(horzExtent + 1, rnd.Next(-4, 4), 0), Quaternion.Euler(0, 0, 90));
            ev = enemy.AddComponent<EnemyView>();
            ev.type = 1;
        }
        else if (i >= 85)
        {
            enemy = Instantiate(GameObject.Find("EnemyStrong"), new Vector3(horzExtent + 1, rnd.Next(-4, 4), 0), Quaternion.Euler(0, 0, 90));
            ev = enemy.AddComponent<EnemyView>();
            ev.type = 2;
        }
    }

    public void addEnemyStage3()
    {
        GameObject enemy = null;
        EnemyView ev = null;
        int i = rnd.Next(100);
        if (i < 35)
        {
            enemy = Instantiate(GameObject.Find("EnemyWeak"), new Vector3(horzExtent + 1, rnd.Next(-4, 4), 0), Quaternion.Euler(0, 0, 90));
            ev = enemy.AddComponent<EnemyView>();
            ev.type = 0;
        }
        else if (i >= 35 && i < 75)
        {
            enemy = Instantiate(GameObject.Find("EnemyMedium"), new Vector3(horzExtent + 1, rnd.Next(-4, 4), 0), Quaternion.Euler(0, 0, 90));
            ev = enemy.AddComponent<EnemyView>();
            ev.type = 1;
        }
        else if (i >= 75)
        {
            enemy = Instantiate(GameObject.Find("EnemyStrong"), new Vector3(horzExtent + 1, rnd.Next(-4, 4), 0), Quaternion.Euler(0, 0, 90));
            ev = enemy.AddComponent<EnemyView>();
            ev.type = 2;
        }
    }

    public void enemyDestroyed(int points)
    {
        spawnerPresenter.addPoints(points);
    }

    public void printPoints(int points)
    {
        scoreText.text = "Score: " + points.ToString();
    }

    public void addBonus(string name)
    {
        GameObject.Find("Player").GetComponent<PlayerView>().addBonus(name);
    }
    
    public int getPoints()
    {
        return spawnerPresenter.getPoints();
    }

}
