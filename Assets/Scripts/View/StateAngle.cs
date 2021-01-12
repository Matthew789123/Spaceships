using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAngle : IState
{
    private int direction = 0;

    public int[] move(Rigidbody2D rigidbody2D)
    {
        switch (direction)
        {
            case 0:
                if (rigidbody2D.IsTouching(GameObject.Find("WallTop").GetComponent<BoxCollider2D>()))
                    direction = 1;
                return new int[2] { 1, -1 };
            case 1:
                if (rigidbody2D.IsTouching(GameObject.Find("WallBottom").GetComponent<BoxCollider2D>()))
                    direction = 0;
                return new int[2] { -1, -1 };
        }
        return new int[2] { 0, -1 };
    }
}
