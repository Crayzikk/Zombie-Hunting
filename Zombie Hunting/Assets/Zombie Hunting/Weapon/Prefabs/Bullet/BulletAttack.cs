using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttack : MonoBehaviour
{
    public int damageBullet { get; set; }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Enemy>().TakeDamage(damageBullet);
            Destroy(gameObject);
        }
    }
}
