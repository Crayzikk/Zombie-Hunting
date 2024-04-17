using UnityEngine;

public class MovingZombieWeapon : MonoCache
{
    [SerializeField] private float speedWeapon = 10f;

    public Vector3 directionMovingWeapon { get; set; }

    //Update
    public override void OnTick()
    {
        if(directionMovingWeapon != null)
            transform.position += directionMovingWeapon * speedWeapon * Time.deltaTime;
    }
}
