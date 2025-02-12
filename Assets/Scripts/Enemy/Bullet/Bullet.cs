﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void Update()
    {
        transform.Translate(Vector3.down * 8f * Time.deltaTime);
        if (transform.position.y < -8)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Shield"))
        {
            Destroy(gameObject);
            print("Biến mất");
        }
    }
}
