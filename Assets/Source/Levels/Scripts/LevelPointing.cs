using System.Collections;
using UnityEngine;

public class LevelPointing : MonoBehaviour
{
    [SerializeField] private RectTransform _levelPointer;
    [SerializeField] private float _pointerSpeed;
    [SerializeField] private LevelsInitializer _levelsInitializer;

    private LevelButton _currentLevelButton;
    private Coroutine _moveCoroutine;

    private void OnEnable()
    {
        _levelsInitializer.CurrentLevelChanged += OnCurrentLevelChanged;
    }

    private void OnDisable()
    {
        _levelsInitializer.CurrentLevelChanged -= OnCurrentLevelChanged;
    }

    public void SetLevel(LevelButton levelButton)
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
        }

        if (TryGetLevelAnchoredPosition(levelButton, out Vector2 levelPosition))
        {
            _moveCoroutine = StartCoroutine(MovePointerTo(levelPosition));
        }
    }

    public void SetLevelImmediately(LevelButton levelButton)
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
        }

        if (TryGetLevelAnchoredPosition(levelButton, out Vector2 levelAnchoredPosition))
        {
            _levelPointer.anchoredPosition = levelAnchoredPosition;
        }
    }

    private bool TryGetLevelAnchoredPosition(LevelButton levelButton, out Vector2 anchoredPosition)
    {
        if (levelButton == null)
        {
            anchoredPosition = Vector2.zero;
            return false;
        }

        RectTransform levelButtonRectTransform = levelButton.GetComponent<RectTransform>();
        anchoredPosition = levelButtonRectTransform.anchoredPosition;
        return true;
    }

    private IEnumerator MovePointerTo(Vector2 anchoredPosition)
    {
        while (_levelPointer.anchoredPosition != anchoredPosition)
        {
            _levelPointer.anchoredPosition = Vector2.MoveTowards(
                _levelPointer.anchoredPosition, anchoredPosition, _pointerSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private void OnCurrentLevelChanged(LevelButton newCurrentLevelButton)
    {
        if (_currentLevelButton == null)
        {
            _currentLevelButton = newCurrentLevelButton;
            SetLevelImmediately(_currentLevelButton);
        }
    }
}
