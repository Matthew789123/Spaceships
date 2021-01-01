using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesView : MonoBehaviour
{
    private EnemiesPresenter enemiesPresenter;
    private System.Random rnd;

    public EnemiesView()
    {
        enemiesPresenter = new EnemiesPresenter(this);
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
        enemiesPresenter.addEnemy(rnd.Next(3));
    }
}
