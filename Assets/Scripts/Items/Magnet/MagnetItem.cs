using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetItem : MonoBehaviour
{
    public float speed = 15f;
    void Update()
    {
        transform.Rotate(new Vector3(0, 360, 0), speed*Time.deltaTime);   
    }
}
