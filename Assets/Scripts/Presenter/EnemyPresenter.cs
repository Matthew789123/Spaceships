using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPresenter
{
    private EnemyModel enemyModel;
    private EnemyView view;
    private System.Random rnd;

    public EnemyPresenter(EnemyView view)
    {
        rnd = new System.Random();
        int i = rnd.Next(0, 2);
        if (i == 0)
        {
            enemyModel = new WeakEnemyModel();
        }
        else if (i == 1)
        {
            enemyModel = new MidEnemyModel();
        }
        else if (i == 2)
        {
            enemyModel = new StrongEnemyModel();
        }

        this.view = view;
    }

    public void enemyMove(int random)
    {
        view.enemyMove(new Vector2(-1 * enemyModel.speed, random * enemyModel.speed));
    }

    public void gotHit(int damage)
    {
        enemyModel.gotHit(damage);
        if (enemyModel.hp <= 0)
            view.destroyEnemy();
    }
}
