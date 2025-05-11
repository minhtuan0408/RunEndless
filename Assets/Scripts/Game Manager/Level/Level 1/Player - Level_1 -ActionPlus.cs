using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLevel1ActionPlus : MonoBehaviour
{
    private Animator Animator;
    public Player Player;
    public Transform Line;
    private void Start()
    {
        Animator = GetComponent<Animator>();
    }

    
    public void PlayerOff()
    {
        Player.enabled = false;
    }

    public IEnumerator ResetPos()
    {
        while (transform.position != Line.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, Line.position, 2f*Time.deltaTime);
            yield return null;
        }
        
    }

    public IEnumerator MoveUp()
    {
        while (transform.position.y < 2.68f)
        {
            transform.position += Vector3.up * 2f * Time.deltaTime;
            yield return null; // Chờ 1 frame trước khi lặp tiếp
        }

        Debug.Log("Next Level ở đây ");

        SceneManager.LoadScene("Level 1.2");
    }

}
