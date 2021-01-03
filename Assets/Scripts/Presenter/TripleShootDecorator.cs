using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShootDecorator : PlayerPresenterDecorator
{
    public TripleShootDecorator(ShipPresenter presenter) : base(presenter) {}

    public override void shoot()
    {
        if (shipModel.cooldown == 0)
        {
            view.shoot(shipModel.projectileSpeed, shipModel.damage, shipModel.projectileType, shipModel.offset, shipModel.rotation, 0.5f);
            view.shoot(shipModel.projectileSpeed, shipModel.damage, shipModel.projectileType, shipModel.offset, shipModel.rotation, -0.5f);
            presenter.shoot();
        }
    }
}
