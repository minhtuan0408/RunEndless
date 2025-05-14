using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public Animator anim;
    public float TimeChangeScene;

    public ShopData shopData;

    public PlayerData playerData;

   
    public void NextLevel() 
    {
        UpdateData();
        StartCoroutine(Play());
    }

    public IEnumerator Play()
    {
        anim.SetTrigger("Action");
        PlayerPrefs.SetInt("CurrentHP", 3);
        PlayerPrefs.SetInt("CurrentScore", 0);
        PlayerPrefs.Save();
        yield return new WaitForSeconds(TimeChangeScene);
        MapLevelUIManager.instance.LoadThisLevel();
    }

    private void UpdateData()
    {
        playerData.TimeMagnet = 4 + shopData.shopItems.skillList[0].level;
        playerData.TimeShield = 4 + shopData.shopItems.skillList[1].level;
    }
}
