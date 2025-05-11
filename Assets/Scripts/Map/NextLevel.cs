using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{ 

    public Animator animator;

    public SpriteRenderer Sprite;
    private void Awake()
    {
        Sprite = GetComponent<SpriteRenderer>();
    }


    private void OnEnable()
    {
        StartCoroutine(AppearPort(3f));
    }

    IEnumerator AppearPort(float time)
    {
        float timeElapsed = 0f;
        while (timeElapsed < time)
        {
            float alpha = timeElapsed / time ;
            Sprite.color = new Color(1f, 1f, 1f, alpha);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        yield return null;
    }
}
