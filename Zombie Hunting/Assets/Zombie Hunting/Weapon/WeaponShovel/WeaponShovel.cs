using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShovel : MonoCache
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform player;

    private bool reloadBeforeThrowning = false;
    private Timer timer;
    
    private void Start() 
    {
        timer = new Timer(0.5f);   
    }

    //Update
    public override void OnTick()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && PlayerMovement.isPlayning && !reloadBeforeThrowning && !CheckPointerEnter.poinetEnterInInterface && Inventory.numberOfWeaponShovel > 0)
        {
            ThrowWeapon();
        }
        else if(reloadBeforeThrowning)
        {
            timer.RunTimer(SetFalseReloadBeforeThrowning);
        }
    }

    private void ThrowWeapon()
    {   
        reloadBeforeThrowning = true;

        Vector3 clickPosition = Mouse.GetMousePosition();
        
        Vector3 direction = (clickPosition - transform.position).normalized;
        GameObject weapon = Instantiate(prefab, player.position, Quaternion.identity);

        weapon.GetComponent<MovingWeapon>().SetDirectionMoving(direction);
        
        Inventory.numberOfWeaponShovel--;

        Destroy(weapon, 10f);
    }

    private void SetFalseReloadBeforeThrowning()
    {
        reloadBeforeThrowning = false;
    }
}
