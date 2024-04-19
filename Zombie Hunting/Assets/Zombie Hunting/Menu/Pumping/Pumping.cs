using UnityEngine;
using UnityEngine.UI;

public class Pumping : MonoCache
{
    [SerializeField] private Text speedUpPriceUI;
    [SerializeField] private Text powerUpPriceUI;
    [SerializeField] private Text shootUpPriceUI;
    [SerializeField] private Text healthUpPriceUI;
    
    public static int speedUpPrice = 25;
    public static int powerUpPrice = 25;
    public static int shootUpPrice = 25;
    public static int healthUpPrice = 25;
    
    public override void OnTick()
    {
        if(!PlayerMovement.isPlayning)
            SetPricePumping();
    }

    private void SetPricePumping()
    {
        speedUpPriceUI.text = speedUpPrice.ToString();
        powerUpPriceUI.text = powerUpPrice.ToString();
        shootUpPriceUI.text = shootUpPrice.ToString();
        healthUpPriceUI.text = healthUpPrice.ToString();
    }
}
