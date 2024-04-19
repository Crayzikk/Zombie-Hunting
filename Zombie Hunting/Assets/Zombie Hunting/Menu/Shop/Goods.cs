using UnityEngine;
using UnityEngine.UI;

public class Goods : MonoCache
{
    [SerializeField] private Text weaponShovelPriceUI;
    [SerializeField] private Text weaponPistolPriceUI;
    [SerializeField] private Text weaponRiflePriceUI;
    [SerializeField] private Text weaponShortGunPriceUI;
    [SerializeField] private Text firstAidKitpriceUI;
    [SerializeField] private Text ammoPriceUI;

    public static int weaponShovelPrice = 10;
    public static int weaponPistolPrice = 50;
    public static int weaponRiflePrice = 100;
    public static int weaponShortGunPrice = 150;
    public static int firstAidKitprice = 20;
    public static int ammoPrice = 1;

    // Update 
    public override void OnTick()
    {
        if(!PlayerMovement.isPlayning)
            SetPriceGoods();
    }

    private void SetPriceGoods()
    {
        weaponShovelPriceUI.text = weaponShovelPrice.ToString();
        weaponPistolPriceUI.text = weaponPistolPrice.ToString();
        weaponRiflePriceUI.text = weaponRiflePrice.ToString();
        weaponShortGunPriceUI.text = weaponShortGunPrice.ToString();
        firstAidKitpriceUI.text = firstAidKitprice.ToString();
        ammoPriceUI.text = ammoPrice.ToString();
    }
}
