using UnityEngine;

public class ProjectileEvasion : ZombiePushForce
{
    [SerializeField] private float evasionForce = 80f;
    private Rigidbody2D rigidbody;
    
    public Collider2D bulletCollider2D { get; set; }
    public bool avoidance = false;

    private void Start() 
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    protected override void HandleCollision(Collider2D other)
    {
        if(avoidance)
        {
            this.rigidbody.AddForce(Vector2.up * evasionForce, ForceMode2D.Impulse);
            Invoke("StopKnockback", 0.2f);       
        }
        else
        {
            base.HandleCollision(other);
        }
    }

    protected override void ApplyKnockback(Vector2 direction)
    {
        this.rigidbody.AddForce(direction * impulseForce, ForceMode2D.Impulse);
    }

    protected override void StopKnockback()
    {
        GetComponent<Enemy>().underAttack = false;
        this.rigidbody.velocity = Vector2.zero;
    }
}
