using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerView : MonoBehaviour
{
    private SpawnerPresenter spawnerPresenter;
    private System.Random rnd;

    public SpawnerView()
    {
        spawnerPresenter = new SpawnerPresenter(this);
        rnd = new System.Random();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        spawnerPresenter.addEnemy(rnd.Next(4));
    }

    public void addEnemy()
    {
       GameObject enemy = Instantiate(GameObject.FindGameObjectWithTag("Respawn"), new Vector3(13, rnd.Next(-4, 4), 0), Quaternion.Euler(0, 0, 90));
       enemy.AddComponent<EnemyView>();
    }
}
