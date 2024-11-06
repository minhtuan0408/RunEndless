using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    #region TouchInput
    private float lastTapTime = 0;
    private float doubleTapThreshold = 0.3f;
    #endregion

    public GameObject[] Bullet;
    private int bulletCount;
   

    private void Awake()
    {
       
        bulletCount = 0;
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && canFire) 
        //{
        //    canFire = false;
        //    Bullet[bulletCount].transform.position = transform.position;
        //    Bullet[bulletCount].SetActive(true);
        //    StartCoroutine(CoolDownFire());
        //    bulletCount++;
        //    if (bulletCount == Bullet.Length) 
        //    {
        //        bulletCount = 0;
        //    }
        //}

        if (Input.touchCount == 1) 
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began) 
            {
                //print(Time.time);
                if (Time.time  - lastTapTime <= doubleTapThreshold) 
                {
                    lastTapTime = 0;

                    
                    Bullet[bulletCount].transform.position = transform.position;
                    Bullet[bulletCount].SetActive(true);

                    AudioManager.Instance.PlaySFX("Player Fire");

                    StartCoroutine(CoolDownFire());
                    bulletCount++;
                    if (bulletCount == Bullet.Length)
                    {
                        bulletCount = 0;
                    }
                }
                else
                {
                    lastTapTime = Time.time;
                }
            }
        }
    }

    IEnumerator CoolDownFire()
    {
        yield return new WaitForSeconds(0.2f);
        
    }
}
