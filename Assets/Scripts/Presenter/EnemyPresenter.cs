using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPresenter
{
    private ShipModel enemyModel;
    private EnemyView view;
    private System.Random rnd;

    public EnemyPresenter(EnemyView view)
    {
        rnd = new System.Random();
        
        if (view.type == 0)
        {
            enemyModel = new WeakEnemyModel();
        }
        else if (view.type == 1)
        {
            enemyModel = new MidEnemyModel();
        }
        else if (view.type == 2)
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

    public void collidePlayer()
    {
        view.destroyEnemy();
        view.collidePlayer(enemyModel.damage);
    }

    public void shoot()
    {
        if (enemyModel.cooldown == 0)
        {
            enemyModel.shoot();
            view.shoot(enemyModel.projectileSpeed, enemyModel.damage);
        }
    }

    public void cooldownDown()
    {
        enemyModel.cooldownDown();
    }
}
