using UnityEngine;

public class CheckPlayerInZoneAttack : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
            GetComponentInParent<ZombieShooting>().playerInZoneAttack = true;   
    }    

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
            GetComponentInParent<ZombieShooting>().playerInZoneAttack = false;
    }
}
