using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownReductionDecorator : PlayerPresenterDecorator
{
    public CooldownReductionDecorator(ShipPresenter presenter) : base(presenter){}

    public override void cooldownDown()
    {
        for (int i = 0; i < 10; i++)
            presenter.cooldownDown();
    }
}
