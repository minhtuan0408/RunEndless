using System.Collections.Generic;
using UnityEngine;

/// [ExecuteInEditMode] <--> chế độ mới, thực thi ngay khi bấm dừng
/// 
public class ParallaxMid : MonoBehaviour
{
    private float speed;

    public MapDATA MapDATA;
    


    public void Awake() 
    {
        speed = MapDATA.Speed_Mid;    
    }
    private void Update()
    {
        transform.Translate(Vector3.down * 5f * Time.deltaTime);

        if (transform.position.y < MapDATA.Range)
        {
            transform.position = MapDATA.SpawnTranform_Mid;
        }
    }
}