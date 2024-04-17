using UnityEngine;

public class BulletZoneChecker : MonoBehaviour
{    
    private ProjectileEvasion projectileEvasion;

    private void Start() 
    {
        projectileEvasion = GetComponentInParent<ProjectileEvasion>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Bullet" && !projectileEvasion.avoidance)
        {
            projectileEvasion.avoidance = Random.Range(0, 3) == 0;
            projectileEvasion.bulletCollider2D = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Bullet" && projectileEvasion.avoidance)
        {
            projectileEvasion.avoidance = false;
        }
    }

}
