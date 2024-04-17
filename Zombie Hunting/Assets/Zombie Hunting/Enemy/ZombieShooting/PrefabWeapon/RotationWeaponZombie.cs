using UnityEngine;

public class RotationWeaponZombie : MonoCache
{
    [SerializeField] private float speedRotate = 180f;

    //Update
    public override void OnTick()
    {
        transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime);
    }
}
