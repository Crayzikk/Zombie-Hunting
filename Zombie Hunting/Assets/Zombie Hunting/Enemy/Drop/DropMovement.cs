using UnityEngine;

public class DropMovement : MonoCache
{
    public Vector3 targetPositionDeathDrop { get; set; }
    public Vector3 targetPositionCoin { get; set; }
    public bool playerTakeDrop = false;

    private float speed = 5f;

    public override void OnTick()
    {
        if(!playerTakeDrop && targetPositionDeathDrop != null)
            DeathDrop();
            
        if(playerTakeDrop && targetPositionCoin != null)
            PlayerTakeDrop();
        

    }

    private void DeathDrop()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPositionDeathDrop, speed * Time.deltaTime);
    }

    private void PlayerTakeDrop()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPositionCoin, speed * 2 * Time.deltaTime);
        Debug.Log(transform.position);
        Debug.Log(targetPositionCoin);
        if (Vector3.Distance(transform.position, targetPositionCoin) < 0.01f) 
        {
            Inventory.coins++;
            Destroy(gameObject);
        }
    }
}
