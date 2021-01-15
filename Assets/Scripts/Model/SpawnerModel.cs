using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerModel
{
    public int enemiesCount { get; set; }
    public int points { get; set; }
    public int stage { get; set; }

    public SpawnerModel()
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
        if (this.points > 500 && this.points < 1000)
            stage = 1;
        else if (this.points > 1000 && this.points < 1500)
            stage = 2;
        else if (this.points > 1500)
            stage = 3;
    }
    
}
