using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_1_2 : GameManager
{
    public override void Start()
    {
        base.Start();

        player.FreeMove = true;
    }
}
