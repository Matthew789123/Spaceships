using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyModel
{
    public int hp { get; set; }
    public int speed { get; set; }

<<<<<<< HEAD
    public void gotHit()
=======
    public EnemyModel()
    {
        hp = 1;
        speed = 3;
    }

    public void gotHit(int damage)
>>>>>>> 7ebb62948d04098656033e14a91c9a0dee96c1c8
    {
        hp -= damage;
    }
}
