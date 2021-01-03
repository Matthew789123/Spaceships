using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakEnemyModel : ShipModel
{
    // Start is called before the first frame update
    public WeakEnemyModel()
    {
        hp = 1;
        speed = 3;
        projectileSpeed = -4;
        cooldown = 0;
        cooldownMax = 50;
        damage = 1;
        projectileType = "ProjectileWeak";
        rotation = 90;
        offset = -0.7f;
    }
}
