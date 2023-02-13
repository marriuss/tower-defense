using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]
public class LevelEntry : MonoBehaviour, IPointerDownHandler
{
    public event UnityAction<LevelEntry> Clicked;

    public void OnPointerDown(PointerEventData eventData)
    {
        Clicked?.Invoke(this);
    }
}
