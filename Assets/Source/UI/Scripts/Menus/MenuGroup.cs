using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class MenuGroup : MonoBehaviour
{
    [SerializeField] private RaycastTarget _raycastTarget;

    private Stack<MenuView> _activeMenuViews;
    private CanvasGroup _canvasGroup;

    private bool _menuStackEmpty => _activeMenuViews.Count == 0;

    public bool GameIsActive => _menuStackEmpty && _raycastTarget.isActiveAndEnabled == false; 

    private void Awake()
    {
        _activeMenuViews = new Stack<MenuView>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        ChangeAppearance(false);
    }

    public void OpenRaycastTarget()
    {
        if (_menuStackEmpty)
            SetRaycastTarget(true);
    }

    public void CloseLastMenu()
    {
        if (_menuStackEmpty == false)
        {
            MenuView last = _activeMenuViews.Peek();
            Close(last);
        }
    }

    public void Open(MenuView view)
    {
        if (_raycastTarget.isActiveAndEnabled)
            SetRaycastTarget(false);

        if (_menuStackEmpty)
        {
            ChangeAppearance(true);
        }
        else
        {
            _activeMenuViews.Peek().Disappear();
        }

        view.Appear();
        _activeMenuViews.Push(view);
    }

    public void Close(MenuView view)
    {
        MenuView lastActiveController = _activeMenuViews.Pop();

        if (view != lastActiveController)
            return;

        view.Disappear();

        if (_menuStackEmpty)
        {
            ChangeAppearance(false);
        }
        else
        {
            _activeMenuViews.Peek().Appear();
        }
    }

    public void CloseMenus()
    {
        MenuView view;

        while (_menuStackEmpty == false)
        {
            view = _activeMenuViews.Pop();
            view.Disappear();
        }

        ChangeAppearance(false);
    }

    private void ChangeAppearance(bool isVisible)
    {
        Time.timeScale = isVisible ? 0 : 1;
        _canvasGroup.alpha = isVisible ? 1 : 0;
        _canvasGroup.blocksRaycasts = isVisible;
        _canvasGroup.interactable = isVisible;
    }

    private void SetRaycastTarget(bool active)
    {
        _raycastTarget.gameObject.SetActive(active);
        _raycastTarget.enabled = active;
    }
}