using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkilletSummoned : BaseZombie
{
    protected override float speed { get; set; } = 3f;
    protected override int healthEnemy { get; set; } = 70;

    public override int damage { get; set; } = 15;

    private void Start()
    {
        GameObject Objplayer = GameObject.FindGameObjectWithTag("Player");
        player = Objplayer.transform;
        timer = new Timer(0.6f);
    }
    
    protected override void DeathEnemy() => Destroy(gameObject);
}
