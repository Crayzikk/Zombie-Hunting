using UnityEngine;
using UnityEngine.EventSystems;

public class CheckPointerEnter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static bool poinetEnterInInterface = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        poinetEnterInInterface = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        poinetEnterInInterface = false;
    }
}
