using UnityEngine;

public class Inventory : MonoCache
{
    public static int pistol {get; set;}
    public static int rifle {get; set;}
    public static int shortGun {get; set;}
    public static int numberOfWeaponShovel { get; set; }
    public static int ammo { get; set; }
    public static int firstAidKit { get; set; }
    public static int coins { get; set; }
    
    private void Start() 
    {
        pistol = 0;
        rifle = 0;
        shortGun = 0;
        numberOfWeaponShovel = 0;
        ammo = 0;
        firstAidKit = 0;
        coins = 0;   
    }

    // Update
    public override void OnTick()
    {
        numberOfWeaponShovel = Mathf.Max(numberOfWeaponShovel, 0);
        ammo = Mathf.Max(ammo, 0);
        firstAidKit = Mathf.Max(firstAidKit, 0);
        coins = Mathf.Max(coins, 0);
    }

}
