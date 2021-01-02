using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : ShipModel
{
    public PlayerModel()
    {
        hp = 3;
        speed = 5;
        projectileSpeed = 6;
        cooldown = 0;
        cooldownMax = 50;
        damage = 1;
        projectileType = "ProjectilePlayer";
    }
}
