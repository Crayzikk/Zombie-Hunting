using UnityEngine;

#if UNITY_EDITOR
    using UnityEditor;
#endif

public class ButtonsController : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void SetMainMenuAnimation(bool state)
    {
        animator.SetBool("MainMunuButtons", state);
    }

    private void SetShopAnimation(bool state)
    {
        animator.SetBool("MenuShopButton", state);
    }

    private void SetPumpingAnimation(bool state)
    {
        animator.SetBool("MenuPumbingButton", state);
    }

    public void StartPlay()
    {
        SetMainMenuAnimation(true);
        PlayerMovement.isPlayning = true;
    }

    public void EndPlay()
    {
        
    }

    public void OpenShop()
    {
        SetMainMenuAnimation(true);
        SetShopAnimation(true);
    }
    
    public void CloseShop()
    {
        SetShopAnimation(false);
        SetMainMenuAnimation(false);
    }

    public void OpenPumbing()
    {
        SetMainMenuAnimation(true);
        SetPumpingAnimation(true);
    }

    public void ClosePumbing()
    {
        SetPumpingAnimation(false);
        SetMainMenuAnimation(false);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
