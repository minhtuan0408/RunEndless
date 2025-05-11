using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_2 : GameManager
{
    public GameObject Dialogue;

    public override void Start()
    {
        StartCoroutine(TurnOn(Dialogue, 2f));
    }
    
    IEnumerator TurnOn(GameObject game, float time)
    {
        yield return new WaitForSeconds(time);
        game.SetActive(true);
    }
}
