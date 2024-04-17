using UnityEngine;

public class ZombieWeaponAttack : MonoBehaviour
{
    public int damageZombieWeapon { get; set; }
    public Enemy enemy { get; set; }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            if(enemy != null && damageZombieWeapon != null)
            {
                other.GetComponent<Health>().TakeDamage(damageZombieWeapon, enemy.activeRotation);
                Destroy(gameObject);
            }
        }    
    }
}
