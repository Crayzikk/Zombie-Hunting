using UnityEngine;

public class PlayerMovement : MonoCache
{
    [SerializeField] private float time = 0.001f;

    private const int rotationRight = 0;
    private const int rotationLeft = 180;
    private Timer timer;
    private bool isRunning;
    private Animator animator;
    
    public static float speed = 4f;
    public static bool isPlayning;
    public static bool playerAttacked;

    private void Start()
    {
        playerAttacked = false;
        isPlayning = false;
        timer = new Timer();
        animator = GetComponent<Animator>();
    }

    // Updater
    public override void OnTick()
    {
        if(isPlayning && !playerAttacked)
        {
            MovePlayer();
        }
        else if(!isPlayning)
        {
            SetAnimation(false);
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

    public void EndAttack()
    { 
        animator.SetBool("Atack", false);
        playerAttacked = false;
    }
}
