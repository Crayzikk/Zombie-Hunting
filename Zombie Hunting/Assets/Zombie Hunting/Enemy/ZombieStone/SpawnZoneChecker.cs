using UnityEngine;

public class SpawnZoneChecker : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            GetComponentInParent<ZombieStone>().playerInZone = true;
        }    
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            GetComponentInParent<ZombieStone>().playerInZone = false;
        }
    }
}
