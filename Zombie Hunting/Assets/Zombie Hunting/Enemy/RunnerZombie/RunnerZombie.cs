using UnityEngine;

public class RunnerZombie : Enemy
{
    protected override float speed { get; set; } = 5f;
    protected override int healthEnemy { get; set; } = 65;
    
    private Timer timer;
    private ProjectileEvasion projectileEvasion;

    public override int damage { get; set; } = 10;

    private void Awake() 
    {
        FindPlayer();
        projectileEvasion = GetComponent<ProjectileEvasion>();
        timer = new Timer(0.4f);   
    }

    //Update
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
