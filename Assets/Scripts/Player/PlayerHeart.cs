using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeart : MonoBehaviour
{
    public GameObject[] HeartImage;

    public int HeartCount;

    private void Awake()
    {
        HeartCount = HeartImage.Length;
    }


}
