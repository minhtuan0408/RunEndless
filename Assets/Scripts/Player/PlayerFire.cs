using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BulletPooling;

public class PlayerFire : MonoBehaviour
{
    public float fireRate = 0.05f;
    private float nextFireTime = 0f; 


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

    //private void Update()
    //{
    //    if (Input.touchCount > 0 && Time.time >= nextFireTime) 
    //    {
    //        nextFireTime = Time.time + fireRate;
    //        if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Moved)
    //        {
    //            GameObject bullet = BulletPooling.Instance.GetBullet("Blue", bulletTypes[0]); 

    //        }
    //    }
    //}

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            // Kiểm tra nếu thời gian giữa các lần bắn đã qua
            if (Time.time >= nextFireTime)
            {
                // Cập nhật thời gian bắn tiếp theo
                nextFireTime = Time.time + fireRate;

                // Kiểm tra nếu người chơi đang chạm hoặc giữ ngón tay trên màn hình
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    // Lấy đạn từ pool (giả sử BulletPooling.Instance.GetBullet là phương thức trả về một đối tượng đạn)
                    GameObject bullet = BulletPooling.Instance.GetBullet("Blue", bulletTypes[0]);
                    bullet.transform.position = transform.position;
                }
            }
        }
    }


}
