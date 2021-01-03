using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerPresenterDecorator : ShipPresenter
{
    protected ShipPresenter presenter;

    public PlayerPresenterDecorator(ShipPresenter presenter) : base(presenter.view)
    {
        this.presenter = presenter;
        shipModel = presenter.shipModel;
    }

    public override void cooldownDown()
    {
        presenter.cooldownDown();
    }

    public override void move(float moveVertical, float moveHorizontal)
    {
        presenter.move(moveVertical, moveHorizontal);
    }

    public override void shoot()
    {
        presenter.shoot();
    }
}
