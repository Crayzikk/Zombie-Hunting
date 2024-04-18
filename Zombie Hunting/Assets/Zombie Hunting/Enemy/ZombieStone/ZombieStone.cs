using UnityEngine;

public class ZombieStone : Enemy
{
    [SerializeField] private GameObject prefabRebelsSkillet;
    
    private Timer timer;

    protected override float speed { get; set; } = 2f;
    protected override int healthEnemy { get; set; } = 150;
    
    public override int damage { get; set; } = 0;
    public bool playerInZone = false;

    private void Awake() 
    {
        FindPlayer();
        timer = new Timer(5f);    
    }

    // Update
    public override void OnTick()
    {
        if(PlayerMovement.isPlayning)
        {
            if(!playerInZone)
                Move();
            else
                timer.RunTimer(SpawnRebelsSkillet);
        }
    }
    
    private void SpawnRebelsSkillet()
    {
        GameObject rebelsSkillet = Instantiate(prefabRebelsSkillet, transform.position, Quaternion.identity);
        ZombieWave.numberOfEnemy++;
    }
}
