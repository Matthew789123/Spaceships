using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidEnemyModel : ShipModel
{
    // Start is called before the first frame update
    public MidEnemyModel()
    {
        hp = 2;
        speed = 4;
        projectileSpeed = -5;
        cooldown = 0;
        cooldownMax = 50;
        damage = 2;
        projectileType = "ProjectileMedium";
        rotation = 90;
        offset = -0.7f;
    }
}
