using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float Speed = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {

        transform.Translate(Vector3.down * Speed * Time.deltaTime);
        if (transform.position.y < -8f)
        {
            Destroy(gameObject);
        }


    }
}
