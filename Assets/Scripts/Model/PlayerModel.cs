using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    public int hp { get; set; }
    public int speed { get; set; }
    public int projectileSpeed { get; set; }
    public int cooldown { get; set; }
    private int cooldownMax { get; set; }
    public int damage { get; set; }

    public PlayerModel()
    {
        hp = 3;
        speed = 5;
        projectileSpeed = 6;
        cooldown = 0;
        cooldownMax = 50;
        damage = 1;
    }

    public void gotHit()
    {
        hp--;
    }

    public void cooldownDown()
    {
        if (cooldown > 0)
            cooldown--;
    }

    public void shootPlayer()
    {
        cooldown = cooldownMax;
    }
}
