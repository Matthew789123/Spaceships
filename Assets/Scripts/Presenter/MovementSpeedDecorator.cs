using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSpeedDecorator : PlayerPresenterDecorator
{
    public MovementSpeedDecorator(ShipPresenter presenter) : base(presenter) {}

    public override void move(float moveVertical, float moveHorizontal)
    {
        presenter.move(2 * moveVertical, 2 * moveHorizontal);
    }
}
