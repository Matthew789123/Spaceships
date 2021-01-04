using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBonusModel
{
    public int time { get; set; }

    public LifeBonusModel()
    {
        time = 500;
    }

    public void tickTime()
    {
        time--;
    }
}
