using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteFader : SpriteUtils
{
    [SerializeField] private float _fadingOutSpeed;

    private Color? _startColor;
    private Coroutine _coroutine;

    private float _startAlpha => _startColor.HasValue? _startColor.Value.a : 1f;

    private void Start()
    {
        _startColor = SpriteRenderer.color;
    }
    
    public void FadeIn()
    {
        ChangeAlpha(_startAlpha);   
    }

    public void FadeOut()
    {
        StartFadingCoroutine(0);
    }

    private void StartFadingCoroutine(float targetAlpha)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(FadeOut(targetAlpha));
    }

    private IEnumerator FadeOut(float targetAlpha)
    {
        float newAlpha;

        while (SpriteRenderer.color.a > targetAlpha)
        {
            newAlpha = Mathf.MoveTowards(SpriteRenderer.color.a, targetAlpha, _fadingOutSpeed * Time.deltaTime);
            ChangeAlpha(newAlpha);
            yield return null;
        }

        _coroutine = null;
    }

    private void ChangeAlpha(float alpha)
    {
        Color color = SpriteRenderer.color;
        color.a = alpha;
        SpriteRenderer.color = color;
    }
}
