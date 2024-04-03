using UnityEngine;

public class ShortgunAttack : MonoCache
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawn;
    [SerializeField] private int damage = 55;

    private Timer timer;
    private bool shoot = true;
    private int numberOfBullet = 3;

    private void Start() 
    {
        timer = new Timer(0.4f);
    }

    public override void OnTick()
    {
        if(Input.GetKey(KeyCode.Mouse0) && PlayerMovement.isPlayning)
        {
            if(shoot)
            {
                shoot = false;
                Vector3 mousePosition = Mouse.GetMousePosition();
                Vector3 direction = Direction.GetDirection(GetComponent<LookAtMouse>(), transform, mousePosition);
                

                for (int currentBullet = 0; currentBullet < numberOfBullet; currentBullet++)
                {
                    GameObject bullet = Instantiate(bulletPrefab, spawn.position, Quaternion.identity);
                    
                    if(currentBullet > 0)
                    {
                        direction.y += currentBullet == 1 ? 0.2f : -0.4f;
                    }

                    bullet.GetComponent<MovingBullet>().directionMoving = direction; 
                    bullet.GetComponent<BulletAttack>().damageBullet = damage;
                    
                    Destroy(bullet, 20f);
                }
            }
            else 
            {
                timer.RunTimer(SetShootTrue);
            }
        }
    }

    private void SetShootTrue() => shoot = true;
}