using UnityEngine;

public class CheckPlayerInZoneRun : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
            GetComponentInParent<ZombieShooting>().playerInZoneRun = true;   
    }    

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
            GetComponentInParent<ZombieShooting>().playerInZoneRun = false;
    }
}
