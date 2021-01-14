using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPresenter : ShipPresenter
{
    private int counter = 0;
    public EnemyPresenter(ShipView view) : base(view)
    {
        shipModel = createEnemy();
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

    public ShipModel createEnemy()
    {
        switch (view.type)
        {
            case 0:
                return new WeakEnemyModel();
            case 1:
                return new MidEnemyModel();
            default:
                return new StrongEnemyModel();
        }
    }
}
