using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteFlipper : SpriteUtils
{
    [SerializeField] private bool _turnedLeft;
    
    public void TurnSide(bool turningLeft)
    {
        if (_turnedLeft ^ turningLeft)
            Flip();
    }

    public void Flip()
    {
        _turnedLeft = !_turnedLeft;
        SpriteRenderer.flipX = !SpriteRenderer.flipX;
    }
}
