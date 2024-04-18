using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkilletSummoned : Enemy
{
    protected override float speed { get; set; } = 3f;
    protected override int healthEnemy { get; set; } = 70;

    public override int damage { get; set; } = 15;

    private Timer timer;

    private void Awake() 
    {
        FindPlayer();
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
}
