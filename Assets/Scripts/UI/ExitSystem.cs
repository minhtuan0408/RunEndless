using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSystem : MonoBehaviour
{
    public GameObject ThisSystem;

    public GameObject[] GameObjects;



    public void Active()
    {
        foreach(GameObject Object in GameObjects){
            Object.SetActive(true);
            if (Object.transform.childCount > 0) 
            {
                foreach(Transform child in Object.transform)
                {
                    child.gameObject.SetActive(true);
                }
            }
        }

        ThisSystem.SetActive(false);
    }
}
