using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPresenter : ShipPresenter
{
    private int counter = 0;
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

    public override void move(float moveVertical, float moveHorizontal)
    {
        counter++;
        if (counter >= 75)
        {
            counter = 0;
            switch (new System.Random().Next(3))
            {
                case 0:
                    ((EnemyView)view).state = new StateNormal();
                    break;
                case 1:
                    ((EnemyView)view).state = new StateRandom();
                    break;
                case 2:
                    ((EnemyView)view).state = new StateAngle();
                    break;
            }
        }
        base.move(moveVertical, moveHorizontal);
    }

}
