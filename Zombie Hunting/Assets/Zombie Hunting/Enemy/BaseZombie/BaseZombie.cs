using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseZombie : Enemy
{
    [SerializeField] private int healthEnemy = 100;
    [SerializeField] private float speed = 3f;

    private Animator animator;
    private Rigidbody2D rigidbody;
    private Timer timer;

    public override int damage { get; set; } = 15;
    public Transform player;

    private void Start() 
    {
       timer = new Timer(0.6f);
    }

    // Updater
    public override void OnTick()
    {
        if(!isAttack && PlayerMovement.isPlayning)
        {
            Move();
        }
        else if(isAttack)
        {
            timer.RunTimer(SetFalseIsAttack);
        }
    }
    
    public override void TakeDamage(int damage)
    {
        healthEnemy -= damage;
        
        if(healthEnemy < 1)
        {
            Destroy(gameObject);
        }
    }

    protected override void Move()
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

    private void SetFalseIsAttack() => isAttack = false;
}
