using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PointerEnterExitDetector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public event UnityAction<PointerEventData> PointerEntered;
    public event UnityAction<PointerEventData> PointerExited;

    public void OnPointerEnter(PointerEventData eventData)
    {
        PointerEntered?.Invoke(eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PointerExited?.Invoke(eventData);
    }
}
