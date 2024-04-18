using UnityEngine;
using UnityEngine.UI;

public class EndPlayWave : MonoCache
{
    [SerializeField] private Text textEndWave;

    private Animator animator;
    private Timer timer;
    
    public static bool endWave = false;

    private void Start() 
    {
        textEndWave.enabled = false;
        animator = GetComponent<Animator>();
        timer = new Timer(5f);
    }
    
    // Update
    public override void OnTick()
    {
        if(endWave)
        {
            textEndWave.text = $"WAVE {ZombieWave.currentWave} FINISHED";
            textEndWave.enabled = true;
            EndPlay();
            endWave = false;
        }

        if(textEndWave.enabled)
            timer.RunTimer(HideText);
    }

    private void EndPlay()
    {
        animator.SetBool("MainMunuButtons", false);
        PlayerMovement.isPlayning = false;
    }

    private void HideText()
    {
        textEndWave.enabled = false;
    }
}
