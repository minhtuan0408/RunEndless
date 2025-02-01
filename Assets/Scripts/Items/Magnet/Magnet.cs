using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float magnetRange = 5f; // Phạm vi ảnh hưởng của nam châm
    public float magnetForce = 10f; // Lực hút về phía nam châm

  

    private void OnDrawGizmos()
    {
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, magnetRange);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Vector3 direction = transform.position - other.transform.position;
            direction.Normalize();


            other.transform.position = Vector3.MoveTowards(other.transform.position, transform.position, magnetForce * Time.deltaTime);
        }
    }
}
