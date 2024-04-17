using UnityEngine;

public class LevelUp : MonoBehaviour
{
    public static void HealthUp()
    {
        Health.maxHealth += 50;
    }

    public static void PowerUp()
    {
        BaseWeapon.damage += 5;
    }

    public static void SpeedUp()
    {
        PlayerMovement.speed += 0.5f;
    }

    public static void ShootUp()
    {
        ShortgunAttack.damage += 3;
        RilfeAttack.damage += 3;
        PistolAttack.damage += 3;
    }
}
