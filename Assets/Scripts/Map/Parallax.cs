using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public enum TypeMap
    {
        Top, Mid, Bot
    }
    private Material material;
    public MapDATA mapData;
    [SerializeField]private TypeMap typeMap;
    private float speed;

    private void Start()
    {
        switch (typeMap)
        {
            case TypeMap.Top:
                speed = mapData.Speed_Top; 
                break;
            case TypeMap.Mid: 
                speed = mapData.Speed_Mid; 
                break;
            case TypeMap.Bot:
                speed = mapData.Speed_Bot;
                break;

        }
        material = GetComponent<Renderer>().material;
    }
    private void Update()
    {
        Scroll();
    }
    private void Scroll()
    {
        Vector2 offset = material.GetTextureOffset("_MainTex");
        offset += Vector2.up * speed * Time.deltaTime;
        material.SetTextureOffset("_MainTex", offset);
    }
}
