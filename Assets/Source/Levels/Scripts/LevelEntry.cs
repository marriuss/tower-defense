using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D), typeof(CanvasGroup))]
public class LevelEntry : MonoBehaviour, IPointerDownHandler
{
    private const float DisabledAlpha = 0.1f;
    private const float EnabledAlpha = 1f;

    public event UnityAction<LevelEntry> Clicked;

    [SerializeField] private GameObject _inaccessibleLevelView;
    [SerializeField] private GameObject _currentLevelView;
    [SerializeField] private GameObject _completedLevelView;
    [SerializeField] private GameObject _pointerView;

    private CanvasGroup _canvasGroup;
    private LevelState _state;

    public void Init(LevelState levelState)
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = EnabledAlpha;

        _state = levelState;
        _inaccessibleLevelView.SetActive(false);
        _currentLevelView.SetActive(false);
        _completedLevelView.SetActive(false);
        _pointerView.SetActive(false);

        switch (levelState)
        {
            case LevelState.Inaccessible: _inaccessibleLevelView.SetActive(true);
                break;
            case LevelState.Current: 
                _currentLevelView.SetActive(true);
                _pointerView.SetActive(true);
                break;
            case LevelState.Completed: _completedLevelView.SetActive(true);
                break;
            default:
                throw new ArgumentException("Unrecognized level state");
        }
    }

    public void Disable()
    {
        _canvasGroup.alpha = DisabledAlpha;
        enabled = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_state == LevelState.Inaccessible)
        {
            return;
        }

        Clicked?.Invoke(this);
    }
}
