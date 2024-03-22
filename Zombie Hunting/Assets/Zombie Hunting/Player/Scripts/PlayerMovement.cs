using UnityEngine;

public class PlayerMovement : MonoCache
{
    [SerializeField]
    private float speed = 5f;
    private const int rotationRight = 0;
    private const int rotationLeft = 180;
    private float countdownTime = 0.2f;
    private float timer;

    private bool isRunning;
    private Animator animator;

    public static bool isPlayning;
    public static bool playerAttacked;

    private void Start()
    {
        playerAttacked = false;
        isPlayning = false;
        timer = countdownTime;
        animator = GetComponent<Animator>();
    }

    // Updater
    public override void OnTick()
    {
        if(isPlayning)
        {
            MovePlayer();
        }
        
        if(playerAttacked)
        {
            timer -= Time.deltaTime;

            if(timer < 0f)
            {
                timer = countdownTime;
                playerAttacked = false;
                animator.SetBool("Atack", false);
            }
        }
    }

    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical"); 

        if(horizontalInput > 0)
        {
            Rotation(rotationRight);
        }
        else if(horizontalInput < 0)
        {
            Rotation(rotationLeft);
        }

        isRunning = (horizontalInput != 0 || verticalInput != 0) ? true : false;

        SetAnimation(isRunning);
        transform.position += new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime;
    }

    private void Rotation(int turn)
    {
        transform.localRotation = Quaternion.Euler(0, turn, 0);
    }

    private void SetAnimation(bool run)
    {
        animator.SetBool("running", run);
    }
}
