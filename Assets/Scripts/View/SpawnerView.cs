using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerView : MonoBehaviour
{
    private SpawnerPresenter spawnerPresenter;
    private System.Random rnd;

    // Start is called before the first frame update
    void Start()
    {
        spawnerPresenter = new SpawnerPresenter(this);
        rnd = new System.Random();
    }

    private void FixedUpdate()
    {
        spawnerPresenter.addEnemy(rnd.Next(4));
    }

    public void addEnemy()
    {
        GameObject enemy=null;
        int i = rnd.Next(0, 3);
        if (i == 0)
        {
            enemy = Instantiate(GameObject.Find("EnemyWeak"), new Vector3(13, rnd.Next(-4, 4), 0), Quaternion.Euler(0, 0, 90));
        }
        else if (i == 1)
        {
            enemy = Instantiate(GameObject.Find("EnemyMedium"), new Vector3(13, rnd.Next(-4, 4), 0), Quaternion.Euler(0, 0, 90));
        }
        else if (i == 2)
        {
            enemy = Instantiate(GameObject.Find("EnemyStrong"), new Vector3(13, rnd.Next(-4, 4), 0), Quaternion.Euler(0, 0, 90));
        }
        EnemyView ev= enemy.AddComponent<EnemyView>();
        ev.type = i;
    }
}
