using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPresenter : ShipPresenter
{
    public PlayerPresenter(ShipView view) : base(view)
    {
        shipModel = new PlayerModel();
    }
}
