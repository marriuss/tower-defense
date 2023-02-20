using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _attackSound;

    public void PlayAttackSound()
    {
        _attackSound.Play();
    }
}
