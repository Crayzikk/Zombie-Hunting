using UnityEngine;

public class PistolAttack : MonoCache
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawn;
    [SerializeField] private int damage = 40;

    private bool shoot = false;
    private Timer timer;
    private LookAtMouse lookAtMouse;

    private void Start() 
    {
        timer = new Timer(0.3f);
        lookAtMouse = GetComponent<LookAtMouse>();
    }

    public override void OnTick()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && PlayerMovement.isPlayning && !shoot && !CheckPointerEnter.poinetEnterInInterface && Inventory.ammo > 0)
        {
            shoot = true;
            Vector3 mousePos = Mouse.GetMousePosition();
            
            Vector3 direction = Direction.GetDirection(lookAtMouse, transform, mousePos);

            GameObject bullet = Instantiate(bulletPrefab, spawn.position, Quaternion.identity);

            bullet.GetComponent<BulletAttack>().damageBullet = damage;
            bullet.GetComponent<MovingBullet>().directionMoving = direction;

            Destroy(bullet, 20f);
        }
        else if(shoot)
        {
            timer.RunTimer(SetFalseShoot);
        }
    }

    private void SetFalseShoot() => shoot = false;
}
