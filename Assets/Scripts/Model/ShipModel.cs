using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipModel
{
    public int hp { get; set; }
    public int speed { get; set; }
    public int projectileSpeed { get; set; }
    public int cooldown { get; set; }
    protected int cooldownMax { get; set; }
    public int damage { get; set; }
    public string projectileType { get; set; }

    public void gotHit(int damage)
    {
        hp -= damage;
    }

    public void cooldownDown()
    {
        if (cooldown > 0)
            cooldown--;
    }

    public void shoot()
    {
        cooldown = cooldownMax;
    }
}
