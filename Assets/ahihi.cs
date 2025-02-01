using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ahihi : MonoBehaviour
{
    public GameObject Spawn;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            GameObject newgame = Spawn;
            newgame.transform.position = transform.position;
        }
    }
}
