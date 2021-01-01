using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesModel
{
    public List<EnemyView> enemyViews { get; set; }

    public EnemiesModel()
    {
        enemyViews = new List<EnemyView>();
    }

    public void addEnemy()
    {
        enemyViews.Add(new EnemyView());
    }
}
