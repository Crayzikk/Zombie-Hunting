using UnityEngine;

public class Skillet : BaseZombie
{
    protected override float speed { get; set; } = 2f;
    protected override int healthEnemy { get; set; } = 50;

    public override int damage { get; set; } = 10;

    private void Start() 
    {
        GameObject Objplayer = GameObject.FindGameObjectWithTag("Player");
        player = Objplayer.transform;
        timer = new Timer(0.6f);
    }
    
    protected override void DeathEnemy() => Destroy(gameObject);
}
