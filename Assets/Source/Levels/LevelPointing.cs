using System.Collections;
using UnityEngine;

public class LevelPointing : MonoBehaviour
{
    [SerializeField] private RectTransform[] _levels;
    [SerializeField] private RectTransform _levelPointer;
    [SerializeField] private float _pointerSpeed;

    private Coroutine _moveCoroutine;

    private void Start()
    {
        SetLevelImmediately(0);
    }

    public void SetLevel(int index)
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
        }

        _moveCoroutine = StartCoroutine(MovePointerTo(_levels[index]));
    }

    public void SetLevelImmediately(int index)
    {
        _levelPointer.anchoredPosition = _levels[index].anchoredPosition;
    }

    private IEnumerator MovePointerTo(RectTransform levelTransform)
    {
        while (_levelPointer.anchoredPosition != levelTransform.anchoredPosition)
        {
            _levelPointer.anchoredPosition = Vector3.MoveTowards(
                _levelPointer.anchoredPosition, levelTransform.anchoredPosition, _pointerSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
