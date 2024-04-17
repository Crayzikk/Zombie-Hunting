using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseZombie : Enemy
{
    [SerializeField] private GameObject prefabSkillet;
    
    protected Timer timer;

    protected override float speed { get; set; } = 3f;
    protected override int healthEnemy { get; set; } = 100;
    
    public override int damage { get; set; } = 15;
    
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

    protected override void DeathEnemy()
    {
        int rand = Random.Range(0, 4);
        if(rand == 0)
            Instantiate(prefabSkillet, transform.position, Quaternion.identity);
 
        base.DeathEnemy();
    }
}
