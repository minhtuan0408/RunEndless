using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed;
    public GameObject posisionBuleet;
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime );       
        if ( transform.position.y > 16)
        {
     
            gameObject.SetActive(false);
            

        }
    }
}
