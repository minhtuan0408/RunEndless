using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBullet : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (transform.position.y > 16)
        {

            transform.position = new Vector2(0, 0);
            gameObject.SetActive(false);
            BulletPooling.Instance.ReturnPool(gameObject, "Blue");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss"))
        {
            transform.position = new Vector2(0, 0);
            gameObject.SetActive(false);
            BulletPooling.Instance.ReturnPool(gameObject, "Blue");
        }
    }
}
