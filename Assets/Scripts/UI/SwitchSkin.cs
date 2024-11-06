using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class SwitchSkin : MonoBehaviour
{
    #region Controller
    private Vector2 startTouch;
    private Vector2 endTouch;
    #endregion

    public GameObject[] SkinList;

    private int currentSkin;

    private void Awake()
    {
        currentSkin = 0;
    }

    private void Start()
    {
        SkinList[currentSkin].gameObject.SetActive(true);
    }
    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) 
        {
            startTouch = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouch = Input.GetTouch(0).position;

            if (endTouch.x < startTouch.x)
            {
                SwitchLeft();
            }

            if (endTouch.x > startTouch.x)
            {
                SwitchRight();
            }
        }
    }

    private void SwitchLeft()
    {
        SkinList[currentSkin].SetActive(false);
        if (currentSkin == SkinList.Length - 1)
        {
            currentSkin = 0;
        }
        else
        {
            currentSkin++;
        }
        ChangeSkin(currentSkin);

    }

    private void SwitchRight()
    {
        SkinList[currentSkin].SetActive(false);
        if (currentSkin == 0)
        {
            currentSkin = SkinList.Length - 1;
        }
        else
        {
            currentSkin--;
        }

        ChangeSkin(currentSkin);

    }

    private void ChangeSkin(int index)
    {
        SkinList[index].gameObject.SetActive(true);
        SellectSkin(index);
    }

    private void SellectSkin(int index)
    {
        PlayerPrefs.SetInt("SelectedSkin", index);
        PlayerPrefs.Save();
    }
}
