using UnityEngine;

public class GlobalUpdate : MonoBehaviour
{
    private void Update() 
    {
        for (int index = 0; index < MonoCache.allUpdate.Count; index++)
        {
            MonoCache.allUpdate[index].Tick();            
        }
    }
}
