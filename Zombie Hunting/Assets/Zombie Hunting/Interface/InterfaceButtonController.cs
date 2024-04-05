using UnityEngine;

public class InterfaceButtonController : MonoBehaviour
{
    [SerializeField] private GameObject baseWeapon;
    [SerializeField] private GameObject shovelWeapon;
    [SerializeField] private GameObject pistolWeapon;
    [SerializeField] private GameObject rifleWeapon;
    [SerializeField] private GameObject shortGunWeapon;

    private void Start() 
    {
        TakeBaseWeapon();
    }

    public void TakeBaseWeapon()
    {
        DeactivateAllWeapons();
        baseWeapon.SetActive(true);
    }

    public void TakeShovelWeapon()
    {
        DeactivateAllWeapons();

        if (Inventory.numberOfWeaponShovel > 0)
            shovelWeapon.SetActive(true);
        else
            TakeBaseWeapon(); 
    }

    public void TakePistolWeapon()
    {
        DeactivateAllWeapons();
        
        if (Inventory.pistol > 0)
            pistolWeapon.SetActive(true);
        else
            TakeBaseWeapon(); 
    }

    public void TakeRifleWeapon()
    {
        DeactivateAllWeapons();
        
        if (Inventory.rifle > 0)
            rifleWeapon.SetActive(true);
        else
            TakeBaseWeapon(); 
    }

    public void TakeShortGunWeapon()
    {
        DeactivateAllWeapons();
        
        if (Inventory.shortGun > 0)
            shortGunWeapon.SetActive(true);
        else
            TakeBaseWeapon(); 
    }

    public void UseFirstAidKit()
    {
        if(Inventory.firstAidKit > 0)
        {
            Health.RecoveryOfHealth();
            Inventory.firstAidKit--;
        }
    }

    private void DeactivateAllWeapons()
    {
        baseWeapon.SetActive(false);
        shovelWeapon.SetActive(false);
        pistolWeapon.SetActive(false);
        rifleWeapon.SetActive(false);
        shortGunWeapon.SetActive(false);
    }
}
