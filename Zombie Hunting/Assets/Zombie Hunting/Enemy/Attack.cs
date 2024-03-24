using UnityEngine;

public class Attack : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            Enemy enemy = GetComponentInParent<Enemy>();

            if(enemy != null)
            {
                if(!enemy.isAttack)
                {
                    Health playerHealth = other.GetComponent<Health>();
                    playerHealth.TakeDamage(enemy.damage, enemy.activeRotation);
                    enemy.isAttack = true;
                }                
            }

        }    
    }  
}
