using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public float Speed = 3f;
    private bool canMove = false;

    public Animator animator;
    private void Start()
    {
        canMove = false;
        StartCoroutine(Counting());
    }

    IEnumerator Counting()
    {
        yield return new WaitForSeconds(3f);
        canMove = true;
    }

    private void Update()
    {
        if (canMove && transform.position.y >= - 4.8f) 
        {
            transform.position += Vector3.down * Speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);    
        }
    }
}
