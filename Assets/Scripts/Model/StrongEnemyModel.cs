using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongEnemyModel : ShipModel
{
    // Start is called before the first frame update
    public StrongEnemyModel()
    {
        hp = 3;
        speed = 5;
        projectileSpeed = -6;
        cooldown = 0;
        cooldownMax = 50;
        damage = 3;
        projectileType = "ProjectileStrong";
        rotation = 90;
        offset = -0.7f;
        points = 200;
    }
}
