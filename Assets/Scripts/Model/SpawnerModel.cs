using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerModel
{
    public int enemiesCount { get; set; }
    public int points { get; set; }
    public int stage { get; set; }
    private static SpawnerModel model;

    public static SpawnerModel getInstance()
    {
        if (model == null)
        {
            model = new SpawnerModel();
        }
        return model;
    }

    private SpawnerModel()
    {
        enemiesCount = 0;
        points = 0;
        stage = 0;
    }

    public void addEnemy()
    {
        enemiesCount++;
    }

    public void addPoints(int points)
    {
        this.points += points;
        enemiesCount--;
        if (this.points > 1000 && this.points < 2000)
            stage = 1;
        else if (this.points > 2000 && this.points < 3000)
            stage = 2;
        else if (this.points > 3000)
            stage = 3;
    }

    

}
