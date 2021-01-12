using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateRandom : IState
{
    public int[] move(Rigidbody2D rigidbody2D)
    {
        System.Random rnd = new System.Random();
        if (rigidbody2D.IsTouching(GameObject.Find("WallTop").GetComponent<BoxCollider2D>()))
            return new int[2] { -1, -1 };
        else if (rigidbody2D.IsTouching(GameObject.Find("WallBottom").GetComponent<BoxCollider2D>()))
            return new int[2] { 1, -1 };
        else
            return new int[2] { rnd.Next(-1, 2), -1 };
    }
}
