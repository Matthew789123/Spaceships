using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPresenter : ShipPresenter
{

    public EnemyPresenter(ShipView view, int type) : base(view)
    {
        System.Random rnd = new System.Random();
        if (type == 0)
        {
            shipModel = new WeakEnemyModel();
        }
        else if (type == 1)
        {
            shipModel = new MidEnemyModel();
        }
        else if (type == 2)
        {
            shipModel = new StrongEnemyModel();
        }
    }

    public override void collidePlayer()
    {
        view.destroy();
        view.collidePlayer(shipModel.damage);
    }
}
