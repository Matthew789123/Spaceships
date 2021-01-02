using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipPresenter
{
    protected ShipModel shipModel;
    protected ShipView view;

    public ShipPresenter(ShipView view)
    {
        this.view = view;
    }

    public void move(float moveVertical, float moveHorizontal)
    {
        view.move(new Vector2(moveHorizontal * shipModel.speed, moveVertical * shipModel.speed));
    }

    public void gotHit(int damage)
    {
        shipModel.gotHit(damage);
        if (shipModel.hp <= 0)
            view.destroy();
    }

    public void shoot()
    {
        if (shipModel.cooldown == 0)
        {
            shipModel.shoot();
            view.shoot(shipModel.projectileSpeed, shipModel.damage, shipModel.projectileType);
        }
    }

    public void cooldownDown()
    {
        shipModel.cooldownDown();
    }

    public virtual void collidePlayer(){}
}
