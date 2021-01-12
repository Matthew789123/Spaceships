using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateNormal : IState
{
    public int[] move(Rigidbody2D rigidbody2D)
    {
        return new int[2] { 0, -1 };
    }
}
