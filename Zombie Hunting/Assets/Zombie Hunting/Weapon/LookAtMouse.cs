using UnityEngine;

public class LookAtMouse : MonoCache
{
    [SerializeField] private Transform player;

    private SpriteRenderer spriteRenderer;
    private float limit = 90f;
    
    public bool isLookingUp;
    public bool isLookingDown;

    private void Start() 
    {    
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update
    public override void OnTick()
    {
        if(PlayerMovement.isPlayning && spriteRenderer != null)
        {
            Vector3 mousePos = Mouse.GetMousePosition();

            Vector3 direction = mousePos - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            if(player.localRotation.y == 0)
            {
                spriteRenderer.flipY = false;
                
                if(angle > limit)
                {
                    isLookingUp = true;
                    isLookingDown = false;
                    angle = limit;
                }
                else if(angle < -limit)
                {
                    isLookingUp = false;
                    isLookingDown = true;
                    angle = -limit;
                }
                else
                {
                    isLookingUp = false;
                    isLookingDown = false;
                }
            }
            else
            {
                spriteRenderer.flipY = true;

                if(angle < limit && angle > 0) 
                {
                    isLookingUp = true;
                    isLookingDown = false;
                    angle = limit;
                }
                else if(angle > -limit && angle < 0)
                {
                    isLookingUp = false;
                    isLookingDown = true;
                    angle = -limit;
                }
                else
                {
                    isLookingUp = false;
                    isLookingDown = false;
                }
            }        

            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = rotation;             
        }

    }
}
