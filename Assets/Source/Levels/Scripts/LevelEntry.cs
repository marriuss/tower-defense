using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D), typeof(CanvasGroup))]
public class LevelEntry : MonoBehaviour, IPointerDownHandler
{
    private const float DisabledAlpha = 0.1f;
    private const float EnabledAlpha = 1f;

    public event UnityAction<LevelEntry> Clicked;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = EnabledAlpha;
    }

    public void Disable()
    {
        _canvasGroup.alpha = DisabledAlpha;
        enabled = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Clicked?.Invoke(this);
    }
}
