using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSpeedDecorator : PlayerPresenterDecorator
{
    public MovementSpeedDecorator(ShipPresenter presenter) : base(presenter) {}

    public override void move(float moveVertical, float moveHorizontal)
    {
        presenter.move(1.5f * moveVertical, 1.5f * moveHorizontal);
    }
}
