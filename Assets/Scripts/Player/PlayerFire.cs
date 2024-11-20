using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BulletPooling;

public class PlayerFire : MonoBehaviour
{
    public float fireRate = 0.5f;

    private int PinkBulletLevel;
    private int BlueBulletLevel;

    [SerializeField] private List<BulletType> bulletTypes; // Gán trong Inspector
    private Dictionary<string, BulletType> bulletTypeDict;

    private void Awake()
    {
        // Tạo dictionary từ danh sách BulletType
        bulletTypeDict = new Dictionary<string, BulletType>();
        foreach (var type in bulletTypes)
        {
            if (!bulletTypeDict.ContainsKey(type.name))
            {
                bulletTypeDict.Add(type.name, type);
            }
        }
    }

    private void Update()
    {
        if (Input.touchCount > 0) 
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Moved)
            {
               

                GameObject bullet = BulletPooling.Instance.GetBullet("Blue", bulletTypes[0]); 

            }
        }
    }


}
