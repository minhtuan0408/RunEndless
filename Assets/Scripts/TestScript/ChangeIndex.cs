using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeIndex : MonoBehaviour
{
    public Animator anim;
    public float TimeChangeScene;
    public void LoadNextLevecl()
    {
        StartCoroutine(ChangeScene());
    }
    public void NextLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1 );
    }
    IEnumerator ChangeScene()
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(TimeChangeScene); 
        NextLevel();
        
    }
}
