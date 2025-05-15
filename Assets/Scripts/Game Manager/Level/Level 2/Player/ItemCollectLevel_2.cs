using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemCollectLevel_2 : MonoBehaviour
{
    public TextMeshProUGUI ScrewText;
    public TextMeshProUGUI ScrewdriveText;
    public TextMeshProUGUI WrenchText;


    private int ScrewCount;
    private int ScrewdriveCount;
    private int WrenchCount;

    public Transform Line;

    private bool isDoneMission;
    private void Start()
    {
        ScrewCount = 0;
        ScrewdriveCount = 0 ;
        WrenchCount = 0;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        string tag = collision.gameObject.tag;

        switch (tag)
        {
            case "Screw":
                ScrewCount++;
                ScrewText.text = $"{ScrewCount}/5";
                break;

            case "Screwdrive":
                ScrewdriveCount++;
                ScrewdriveText.text = $"{ScrewdriveCount}/5";
                break;

            case "Wrench":
                WrenchCount++;
                WrenchText.text = $"{WrenchCount}/5";
                break;
        }

        if (ScrewCount >= 5 && ScrewdriveCount >=5 && WrenchCount >= 5)
        {
            Level_2.Instance.TurnOffSpawn();
            StartCoroutine(LoadNextLevel());
        }
    }

    public IEnumerator ResetPos()
    {
        while (transform.position != Line.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, Line.position, 2f * Time.deltaTime);
            yield return null;
        }

    }
    
    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(4f);

        Level_2.Instance.SaveCurrentScore();
        SceneManager.LoadScene("EndGamePlay");
    }

}
