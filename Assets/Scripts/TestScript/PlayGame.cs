using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
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
        PlayerPrefs.SetInt("CurrentHP", 3);
        PlayerPrefs.SetInt("CurrentScore", 0);
        PlayerPrefs.Save();
        yield return new WaitForSeconds(TimeChangeScene);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
