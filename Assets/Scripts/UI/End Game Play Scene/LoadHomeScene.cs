using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadHomeScene : MonoBehaviour
{
    public Animator anim;
    public float TimeChangeScene;
    public void NextLevel()
    {
        StartCoroutine(Play());
    }

    public IEnumerator Play()
    {
        anim.SetTrigger("Action");
        yield return new WaitForSeconds(TimeChangeScene);
        SceneManager.LoadScene("Start Menu");
    }
}
