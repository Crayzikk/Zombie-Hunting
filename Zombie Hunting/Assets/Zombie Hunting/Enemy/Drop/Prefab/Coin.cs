using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            DropMovement dropMovement = GetComponent<DropMovement>();
            dropMovement.playerTakeDrop = true;
        }    
    }
}
