using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoCache
{
    public static int damage = 25; 

    [SerializeField] private Collider2D gameObjectCollider;
    
    private List<Collider2D> triggers = new List<Collider2D>();
    private ContactFilter2D filter;
    private Animator animator;

    private void Start() 
    {
        animator = GetComponentInParent<Animator>();
        Collider2D trigger = gameObjectCollider.GetComponent<Collider2D>();
        
        filter = new ContactFilter2D();
        filter.useLayerMask = true;
        filter.SetLayerMask(LayerMask.GetMask("Enemy"));
        filter.useTriggers = true;
        filter.useDepth = false;
        filter.useNormalAngle = false;
    }

    public override void OnTick()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && !PlayerMovement.playerAttacked && PlayerMovement.isPlayning && !CheckPointerEnter.poinetEnterInInterface)
        {
            Attack();
        }
    }
    
    private void Attack() 
    {
        animator.SetBool("Atack", true);
        PlayerMovement.playerAttacked = true;
        triggers.Clear();

        Physics2D.OverlapCollider(gameObjectCollider, filter, triggers);
        if(triggers.Count > 0)
        {
            int randomEnemy = Random.Range(0, triggers.Count - 1);
            Enemy enemy = triggers[randomEnemy].GetComponent<Enemy>();

            if(enemy != null)
                enemy.TakeDamage(damage);
        }
    }
}
