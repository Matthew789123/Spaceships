using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerModel
{
    public int enemiesCount { get; set; }

    public SpawnerModel()
    {
        enemiesCount = 0;
    }

    public void addEnemy()
    {
        enemiesCount++;
    }
}
