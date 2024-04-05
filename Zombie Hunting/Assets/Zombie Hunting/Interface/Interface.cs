using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoCache
{
    [SerializeField] private Text numberOfCoins;
    [SerializeField] private Text numberOfHealth;
    [SerializeField] private Text numberOfAmmo;


    // Update
    public override void OnTick()
    {
        numberOfCoins.text = Inventory.coins.ToString();
        numberOfHealth.text = Health.health.ToString();
        numberOfAmmo.text = Inventory.ammo.ToString();
    }
}
