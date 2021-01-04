using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBonusPresenter
{
    private LifeBonusModel bonusModel;
    private LifeBonusView view;

    public LifeBonusPresenter(LifeBonusView view)
    {
        this.view = view;
        bonusModel = new LifeBonusModel();
    }

    public void timeTick()
    {
        bonusModel.tickTime();
        if (bonusModel.time == 0)
            view.destroy();
    }
}
