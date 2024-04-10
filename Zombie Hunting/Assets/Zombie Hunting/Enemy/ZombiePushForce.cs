using UnityEngine;

public class ZombiePushForce : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private float impulseForce = 15f;
    
    private void Start() 
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        HandleCollision(other);
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        HandleCollision(other);
    }

    private void HandleCollision(Collider2D other)
    {
        if (other.CompareTag("Bullet") || (other.CompareTag("BaseAttack") && PlayerMovement.playerAttacked))
        {
            Vector2 normal = other.transform.position - transform.position;
            normal.Normalize();
            
            Vector2 knockbackDirection = (normal.x < 0 && normal.x > -1) ? Vector2.right : Vector2.left;
            ApplyKnockback(knockbackDirection);
            Invoke("StopKnockback", 0.2f);
        }
    }

    private void ApplyKnockback(Vector2 direction)
    {
        rigidbody.AddForce(direction * impulseForce, ForceMode2D.Impulse);
    }

    private void StopKnockback()
    {
        rigidbody.velocity = Vector2.zero;
    }  
}
