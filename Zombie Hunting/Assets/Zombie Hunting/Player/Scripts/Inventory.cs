using UnityEngine;

public class Inventory : MonoCache
{
    public static int pistol {get; set;} = 0;
    public static int rifle {get; set;} = 0;
    public static int shortGun {get; set;} = 0;
    public static int numberOfWeaponShovel { get; set; } = 0;
    public static int ammo { get; set; } = 0;
    public static int firstAidKit { get; set; } = 0;
    public static int coins { get; set; } = 0;
    
    public override void OnTick()
    {
        numberOfWeaponShovel = Mathf.Max(numberOfWeaponShovel, 0);
        ammo = Mathf.Max(ammo, 0);
        firstAidKit = Mathf.Max(firstAidKit, 0);
        coins = Mathf.Max(coins, 0);
    }

}
