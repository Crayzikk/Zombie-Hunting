using UnityEngine;

public class Skillet : Enemy
{
    protected override float speed { get; set; } = 2f;
    protected override int healthEnemy { get; set; } = 50;

    public override int damage { get; set; } = 10;

    private Timer timer;

    private void Start() 
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
