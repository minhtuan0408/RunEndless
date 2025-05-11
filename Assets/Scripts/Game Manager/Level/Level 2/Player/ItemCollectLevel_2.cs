using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectLevel_2 : MonoBehaviour
{
    private Collider2D coll;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
