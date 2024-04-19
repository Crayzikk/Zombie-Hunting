using UnityEngine;

public class ShortgunAttack : MonoCache
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawn;

    private Timer timer;
    private bool shoot = false;
    private int numberOfBullet = 3;

    public static int damage = 55;

    private void Awake() 
    {
        timer = new Timer(1.5f);
    }

    public override void OnTick()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && PlayerMovement.isPlayning && shoot && !CheckPointerEnter.poinetEnterInInterface && Inventory.ammo >= 3)
        {

            shoot = false;
            Vector3 mousePosition = Mouse.GetMousePosition();
            Vector3 direction = Direction.GetDirection(GetComponent<LookAtMouse>(), transform, mousePosition);

            Inventory.ammo -= 3;
            
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
        else if(!shoot)
        {
            timer.RunTimer(SetShootTrue);
        }
    }

    private void SetShootTrue() => shoot = true;
}
