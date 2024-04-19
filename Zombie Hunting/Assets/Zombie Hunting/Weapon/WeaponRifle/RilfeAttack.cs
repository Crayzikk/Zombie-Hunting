using UnityEngine;

public class RilfeAttack : MonoCache
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawn;

    private Timer timer;
    private bool shoot = false;

    public static int damage = 40;

    private void Start() 
    {
        timer = new Timer(0.2f);    
    }

    // Update
    public override void OnTick()
    {
        if(Input.GetKey(KeyCode.Mouse0) && PlayerMovement.isPlayning && !CheckPointerEnter.poinetEnterInInterface && Inventory.ammo > 0)
        {
            if(shoot)
            {
                shoot = false;
                Vector3 mousePosition = Mouse.GetMousePosition();
                Vector3 direction = Direction.GetDirection(GetComponent<LookAtMouse>(), transform, mousePosition);
                
                GameObject bullet = Instantiate(bulletPrefab, spawn.position, Quaternion.identity);

                bullet.GetComponent<BulletAttack>().damageBullet = damage;
                bullet.GetComponent<MovingBullet>().directionMoving = direction;

                Inventory.ammo--;

                Destroy(bullet, 20f);
            }
            else 
            {
                timer.RunTimer(SetShootTrue);
            }
        }
    }

    private void SetShootTrue() => shoot = true; 
}
