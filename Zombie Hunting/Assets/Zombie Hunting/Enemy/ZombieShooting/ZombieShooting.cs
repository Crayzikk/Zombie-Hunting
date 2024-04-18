using UnityEngine;

public class ZombieShooting : Enemy
{
    public bool playerInZoneAttack = false;
    public bool playerInZoneRun = false;
    public override int damage { get; set; } = 20;

    [SerializeField] private GameObject prefabBulletZombie;
    
    private Timer timer;
    private Animator animator;

    protected override float speed { get; set; } = 3f;
    protected override int healthEnemy { get; set; } = 90;
    
    private void Start() 
    {
        FindPlayer();
        animator = GetComponent<Animator>();
        timer = new Timer(3f);
    }

    // Update
    public override void OnTick()
    {
        if(PlayerMovement.isPlayning && animator != null)
        {
            if(playerInZoneAttack && !playerInZoneRun)
            {
                animator.SetBool("Shoot", true);
                RotationZombie((transform.position.x < player.position.x) ? rotationRight : rotationLeft);
                timer.RunTimer(ZombieShoot);
            }
            else
            {
                animator.SetBool("Shoot", false);
                Move();
            }
        }
    }

    protected override void Move()
    {
        if(playerInZoneAttack && playerInZoneRun)
        {
            bool playerIsLeft = (transform.position.x < player.position.x);
            Vector3 direction = playerIsLeft ? Vector2.left : Vector2.right;

            transform.position += direction * speed * Time.deltaTime;
            RotationZombie(playerIsLeft ? rotationLeft : rotationRight);
        }
        else
        {
            base.Move();
        }
    }

    private void ZombieShoot()
    {
        Vector2 direction = (player.position - transform.position).normalized;

        GameObject bulletZombie = Instantiate(prefabBulletZombie, transform.position, Quaternion.identity);

        bulletZombie.GetComponent<MovingZombieWeapon>().directionMovingWeapon = direction;

        ZombieWeaponAttack zombieWeaponAttack = bulletZombie.GetComponent<ZombieWeaponAttack>();
        zombieWeaponAttack.enemy = this;
        zombieWeaponAttack.damageZombieWeapon = damage;

        Destroy(bulletZombie, 20f);
    }
}
