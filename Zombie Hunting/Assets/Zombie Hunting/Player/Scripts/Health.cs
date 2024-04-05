using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static int maxHealth = 100;
    public static int health = maxHealth;

    private Rigidbody2D rb;
    private static int recoveryOfHealth = 25;
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
            health = 0;
            Destroy(gameObject);
        }
        else
        {
            rb.AddForce((directtion == 0 ? Vector2.right : Vector2.left)* impulseForce, ForceMode2D.Impulse);
            Invoke("StopKnockback", 0.2f);
        }
    }

    public static void RecoveryOfHealth()
    {
        health += recoveryOfHealth;

        if(health > maxHealth)
            health = maxHealth;
    }
    
    private void StopKnockback()
    {
        rb.velocity = Vector2.zero;
    }
}
