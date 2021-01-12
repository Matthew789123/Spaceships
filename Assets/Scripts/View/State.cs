using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    int[] move(Rigidbody2D rigidbody2D);
}
