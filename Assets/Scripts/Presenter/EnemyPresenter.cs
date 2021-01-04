using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPresenter : ShipPresenter
{

    public EnemyPresenter(ShipView view) : base(view)
    {
        System.Random rnd = new System.Random();
        if (view.type == 0)
        {
            shipModel = new WeakEnemyModel();
        }
        else if (view.type == 1)
        {
            shipModel = new MidEnemyModel();
        }
        else if (view.type == 2)
        {
            shipModel = new StrongEnemyModel();
        }
    }

    public override void collidePlayer()
    {
        view.destroy(shipModel.points);
        view.collidePlayer(shipModel.damage);
    }
}
