using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {

        transform.Translate(Vector3.down * 5f * Time.deltaTime);
        if (transform.position.y < -8f)
        {
            transform.position = new Vector3(transform.position.x, 12, transform.position.z);
            gameObject.SetActive(false);

        }


    }
}
