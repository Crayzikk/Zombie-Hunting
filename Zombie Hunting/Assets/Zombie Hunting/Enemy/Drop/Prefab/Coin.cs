using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject objectTargetCoin;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            Transform targetCoin = objectTargetCoin.GetComponent<Transform>();
            DropMovement dropMovement = GetComponent<DropMovement>();
            
            dropMovement.playerTakeDrop = true;
            dropMovement.targetPositionCoin = targetCoin.position;
        }    
    }
}
