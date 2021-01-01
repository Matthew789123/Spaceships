using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesPresenter
{
    private EnemiesModel enemiesModel;
    private EnemiesView view;

    public EnemiesPresenter(EnemiesView view)
    {
        enemiesModel = new EnemiesModel();
        this.view = view;
    }

    public void addEnemy(int random)
    {
        if (random == 0 && enemiesModel.enemyViews.Count < 11)
            enemiesModel.addEnemy();
    }
}
