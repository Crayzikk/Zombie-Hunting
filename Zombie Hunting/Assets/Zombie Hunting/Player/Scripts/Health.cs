using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;
    
    private Rigidbody2D rb;
    private float impulseForce = 30f;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage, int directtion)
    {
        health -= damage;
        
        if (health < 1)
        {
            Destroy(gameObject);
        }
        else
        {
            rb.AddForce((directtion == 0 ? Vector2.right : Vector2.left)* impulseForce, ForceMode2D.Impulse);
            Invoke("StopKnockback", 0.2f);
        }
    }
    
    private void StopKnockback()
    {
        rb.velocity = Vector2.zero;
    }
}
