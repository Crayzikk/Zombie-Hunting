using UnityEngine;

public class ShopLogic : MonoBehaviour
{
    public void BuyWeaponShovel()
    {
        if(Goods.weaponShovelPrice <= Inventory.coins)
        {
            DifferencePriceAndCoins(Goods.weaponShovelPrice);
            Inventory.numberOfWeaponShovel++;
        }
    }

    public void BuyWeaponPistol()
    {
        if(Goods.weaponPistolPrice <= Inventory.coins)
        {
            DifferencePriceAndCoins(Goods.weaponPistolPrice);
            Inventory.pistol++;
        }
    }

    public void BuyWeaponRifle()
    {
        if(Goods.weaponRiflePrice <= Inventory.coins)
        {
            DifferencePriceAndCoins(Goods.weaponRiflePrice);
            Inventory.rifle++;
        }
    }

    public void BuyWeaponShortGun()
    {
        if(Goods.weaponShortGunPrice <= Inventory.coins)
        {
            DifferencePriceAndCoins(Goods.weaponShortGunPrice);
            Inventory.shortGun++;
        }
    }

    public void BuyFirstAidKit()
    {
        if(Goods.firstAidKitprice <= Inventory.coins)
        {
            DifferencePriceAndCoins(Goods.firstAidKitprice);
            Inventory.firstAidKit++;
        }
    }

    public void BuyAmmo()
    {
        if(Goods.ammoPrice <= Inventory.coins)
        {
            DifferencePriceAndCoins(Goods.ammoPrice);
            Inventory.ammo++;
        }
    }

    private void DifferencePriceAndCoins(int priceGoods)
    {
        Inventory.coins -= priceGoods;
    }
}
