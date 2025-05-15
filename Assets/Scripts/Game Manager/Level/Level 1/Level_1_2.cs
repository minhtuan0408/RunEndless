using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_1_2 : GameManager
{
    public static Level_1_2 Instance;

    public override void Start()
    {
        base.Start();

        player.FreeMove = true;
        Instance = this;
    }
}
