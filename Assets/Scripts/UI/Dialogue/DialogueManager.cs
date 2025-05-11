using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct DialogueText
{
    public string NameCharacter;
    public string text;
    public int STT;
}

public class DialogueManager : MonoBehaviour
{
    public Text Text;
    public GameObject LoadNext;
    public DialogueText[] Messenger;

    private int currentIndex = 0;
    public bool canShowNext;
    void Start()
    {
        StartCoroutine(WaitForNext());
        if (Messenger.Length > 0)
        {
            ShowDialogue(0);
        }

        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.touchCount > 0 && canShowNext)
        {
            Touch touch = Input.GetTouch(0); 

            if (touch.phase == TouchPhase.Began)  
            {
                StartCoroutine(WaitForNext());
                ShowNext();
            }
        }
    }

    public void ShowDialogue(int index)
    {
        if (index >= 0 && index < Messenger.Length)
        {
            Text.text = Messenger[index].text;
            currentIndex = index;
        }
    }

    public void ShowNext()
    {
        int next = currentIndex + 1;
        if (next < Messenger.Length)
        {
            ShowDialogue(next);
        }
        else
        {
            StopAllCoroutines();
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }
    }

    private IEnumerator WaitForNext()
    {
        LoadNext.SetActive(false);
        canShowNext = false;
        yield return new WaitForSecondsRealtime(2f);
        canShowNext = true;
        LoadNext.SetActive(true);

    }
}
