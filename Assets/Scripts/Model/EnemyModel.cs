using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel
{
    public int hp { get; set; }
    public int speed { get; set; }

    public EnemyModel()
    {
        hp = 1;
        speed = 3;
    }

    public void gotHit(int damage)
    {
        hp -= damage;
    }
}
