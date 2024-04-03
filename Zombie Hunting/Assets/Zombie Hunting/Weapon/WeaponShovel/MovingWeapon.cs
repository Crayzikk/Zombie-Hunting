using UnityEngine;

public class MovingWeapon : MonoCache
{
    [SerializeField] private float speedWeapon = 5f;
    
    private Vector3 directionMoving;
    
    //Update
    public override void OnTick()
    {
        if(directionMoving != null)
        {
            transform.position += directionMoving * speedWeapon * Time.deltaTime;
        }
    }

    public void SetDirectionMoving(Vector3 dir) => directionMoving = dir;
}
