using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyModel
{
    public int hp { get; set; }
    public int speed { get; set; }

    public void gotHit()
    {
        hp--;
    }
}
