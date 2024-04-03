using UnityEngine;

public class AttackWeapon : MonoBehaviour
{
    [SerializeField] private int damage = 35;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }    
    }
}
