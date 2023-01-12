using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteFlipper : MonoBehaviour
{
    [SerializeField] private bool _turnedLeft;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TurnSide(bool turningLeft)
    {
        if (_turnedLeft ^ turningLeft)
            Flip();
    }

    public void Flip()
    {
        _turnedLeft = !_turnedLeft;
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
    }
}
