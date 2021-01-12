using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPresenter : ShipPresenter
{
    public PlayerPresenter(ShipView view) : base(view)
    {
        shipModel = new PlayerModel();
        view.type = 3;
    }

    public override void gotHit(int damage)
    {
        base.gotHit(damage);
        view.printLifes(shipModel.hp);
    }
}
