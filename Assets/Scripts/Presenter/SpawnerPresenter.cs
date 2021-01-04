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

    public void addEnemy()
    {
        if (spawnerModel.enemiesCount > 11)
            return;
        spawnerModel.addEnemy();
        if (spawnerModel.stage == 0)
            view.addEnemyStage1();
        else if (spawnerModel.stage == 1)
            view.addEnemyStage2();
        else
            view.addEnemyStage3();
    }

    public void addPoints(int points)
    {
        int stage = spawnerModel.stage;
        spawnerModel.addPoints(points);
        if (stage != spawnerModel.stage)
        {
            if (spawnerModel.stage == 1)
                view.addBonus("movement");
            else if (spawnerModel.stage == 2)
                view.addBonus("triple");
            else
                view.addBonus("rapid");
        }
        view.printPoints(spawnerModel.points);
    }
}
