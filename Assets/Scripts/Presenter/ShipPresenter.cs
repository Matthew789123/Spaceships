using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipPresenter
{
    public ShipModel shipModel;
    public ShipView view;

    public ShipPresenter(ShipView view)
    {
        this.view = view;
    }

    public virtual void move(float moveVertical, float moveHorizontal)
    {
        view.move(new Vector2(moveHorizontal * shipModel.speed, moveVertical * shipModel.speed));
    }

    public void gotHit(int damage)
    {
        shipModel.gotHit(damage);
        if (shipModel.hp <= 0)
            view.destroy();
    }

    public virtual void shoot()
    {
        if (shipModel.cooldown == 0)
        {
            shipModel.shoot();
            view.shoot(shipModel.projectileSpeed, shipModel.damage, shipModel.projectileType, shipModel.offset, shipModel.rotation, 0);
        }
    }

    public virtual void cooldownDown()
    {
        shipModel.cooldownDown();
    }

    public virtual void collidePlayer(){}
}
