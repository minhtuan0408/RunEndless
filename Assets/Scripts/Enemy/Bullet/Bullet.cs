using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Off());
    }

    IEnumerator Off()
    {
        yield return new WaitForSeconds(8f);
        Destroy(gameObject);
    }
    private void Update()
    {
        transform.Translate(Vector3.down * 8f * Time.deltaTime);
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
