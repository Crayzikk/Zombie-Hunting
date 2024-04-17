using UnityEngine;

public class PumpingLogic : MonoBehaviour
{
    public void PumpingSpeed()
    {
        if(Pumping.speedUpPrice <= Inventory.coins)
        {
            LevelUp.SpeedUp();
            UpPricePumping(ref Pumping.speedUpPrice);
        }
    }

    public void PumpingPower()
    {
        if(Pumping.powerUpPrice <= Inventory.coins)
        {
            LevelUp.PowerUp();
            UpPricePumping(ref Pumping.powerUpPrice);
        }
    }

    public void PumpingShoot()
    {
        if(Pumping.shootUpPrice <= Inventory.coins)
        {
            LevelUp.ShootUp();
            UpPricePumping(ref Pumping.shootUpPrice);
        }
    }

    public void PumpingHealth()
    {
        if(Pumping.healthUpPrice <= Inventory.coins)
        {
            LevelUp.HealthUp();
            UpPricePumping(ref Pumping.healthUpPrice);
        }
    }

    private void UpPricePumping(ref int price)
    {
        Inventory.coins -= price;
        price += 50;
    }
}
