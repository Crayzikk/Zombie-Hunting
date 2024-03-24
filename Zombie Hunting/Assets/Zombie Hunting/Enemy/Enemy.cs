using UnityEngine;

public abstract class Enemy : MonoCache
{
    protected const int rotationRight = 0;
    protected const int rotationLeft = 180;
    
    public bool isAttack = false;
    public abstract int damage { get; set; }

    public int activeRotation;

    protected void RotationZombie(int turn)
    {
        transform.localRotation = Quaternion.Euler(0, turn, 0);
        activeRotation = turn;
    }

    protected abstract void Move();

    public abstract void TakeDamage(int damage);
}
