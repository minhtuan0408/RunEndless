using System.Collections.Generic;
using UnityEngine;

/// [ExecuteInEditMode] <--> chế độ mới, thực thi ngay khi bấm dừng
/// 
public class ParallaxBottom : MonoBehaviour
{
    private float speed;
    public MapDATA mapData;
    private void Awake()
    {
        speed = mapData.Speed_Top;
    }
    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < mapData.Range)
        {
            transform.position = mapData.SpawnTranform_Bot;
        }
    }
}