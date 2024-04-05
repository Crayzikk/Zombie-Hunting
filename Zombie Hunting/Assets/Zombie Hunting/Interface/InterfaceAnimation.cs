using UnityEngine;

public class InterfaceAnimation : MonoCache
{
    private Animator animator;

    private void Start() 
    {
        animator = GetComponent<Animator>();
    }

    public override void OnTick()
    {
        if(PlayerMovement.isPlayning)
        {
            animator.SetBool("InterfaceVisiale", true);
        }
        else
        {
            animator.SetBool("InterfaceVisiale", false);
        }
    }
}
