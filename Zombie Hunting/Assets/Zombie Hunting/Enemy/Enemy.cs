using UnityEngine;

public abstract class Enemy : MonoCache
{
    protected const int rotationRight = 0;
    protected const int rotationLeft = 180;
    protected abstract int healthEnemy { get; set; }
    protected abstract float speed { get; set; }  
    
    public bool underAttack = false;
    public Transform player;
    public bool isAttack = false;
    public abstract int damage { get; set; }
    public int activeRotation;

    protected void RotationZombie(int turn)
    {
        transform.localRotation = Quaternion.Euler(0, turn, 0);
        activeRotation = turn;
    }

    protected virtual void Move()
    {
        if(player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            RotationZombie((transform.position.x < player.position.x) ? rotationRight : rotationLeft);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public virtual void TakeDamage(int damage)
    {
        underAttack = true;
        healthEnemy -= damage;
        
        if(healthEnemy < 1)
            DeathEnemy();
    }

    protected virtual void DeathEnemy()
    {
        Destroy(gameObject);
        GetComponent<SpawnDrop>().SpawnsDrop();
        ZombieWave.numberOfEnemy--;
    }

    protected virtual void FindPlayer()
    {
        GameObject Objplayer = GameObject.FindGameObjectWithTag("Player");
        player = Objplayer.transform;
    }
    
    protected void SetFalseIsAttack() => isAttack = false;
}
