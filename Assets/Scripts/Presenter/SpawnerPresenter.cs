using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPresenter
{
    private SpawnerModel spawnerModel;
    private SpawnerView view;

    public SpawnerPresenter(SpawnerView view)
    {
        spawnerModel = new SpawnerModel();
        this.view = view;
    }

    public void addEnemy(int random)
    {
        if (random == 0 && spawnerModel.enemiesCount < 10)
        {
            spawnerModel.addEnemy();
            view.addEnemy();
        }
    }
}
