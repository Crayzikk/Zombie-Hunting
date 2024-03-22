using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseZombie : Enemy
{
    [SerializeField] private int healthEnemy = 100;
    [SerializeField] private float speed = 3f;

    private Animator animator;
    private Rigidbody2D rigidbody;
    private float countdownTime = 1f;
    private float timer;

    public override int damage { get; set; } = 15;
    public Transform player;

    private void Start() 
    {
        timer = countdownTime;
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
            timer -= Time.deltaTime;

            if(timer < 0f)
            {
                timer = countdownTime;
                isAttack = false;
            }
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
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        RotationZombie((transform.position.x < player.position.x) ? rotationRight : rotationLeft);
    }
}
