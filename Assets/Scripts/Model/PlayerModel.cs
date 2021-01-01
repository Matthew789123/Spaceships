using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    public int hp { get; set; }
    public int speed { get; set; }

    public PlayerModel()
    {
        hp = 3;
        speed = 5;
    }

    public void gotHit()
    {
        hp--;
    }
}
