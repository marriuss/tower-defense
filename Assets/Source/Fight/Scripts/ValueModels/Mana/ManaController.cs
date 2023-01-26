using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaController : MonoBehaviour
{
    [SerializeField, Min(MinStartMana)] private int _startMana;
    [SerializeField, Min(MinMaxMana)] private int _maxMana;
    [SerializeField, Min(MinFillingDelay)] private float _fillingDelaySeconds;

    private const int MinStartMana = 0;
    private const int MinMaxMana = 1;
    private const float MinFillingDelay = 0.1f;
    private const int Increment = 1;

    private Coroutine _fillingCoroutine;
    private Mana _mana;

    public int Mana => _mana == null ? 0 : _mana.Value;

    private void Awake()
    {
        _mana = new Mana(_startMana, _maxMana);
    }

    private void Update()
    {
        if (_startMana < _maxMana && _fillingCoroutine == null)
            _fillingCoroutine = StartCoroutine(FillMana());
    }

    private void OnValidate()
    {
        if (_startMana > _maxMana)
            _startMana = _maxMana;
    }

    public bool CanSpendMana(int value) => 0 <= value && value <= Mana;

    public void SpendMana(int amount)
    {
        _mana.DecreaseValue(amount);
    }

    private IEnumerator FillMana()
    {
        WaitForSeconds waitForSeconds = new(_fillingDelaySeconds);

        while (Mana < _maxMana)
        {
            _mana.IncreaseValue(Increment);
            yield return waitForSeconds;
        }

        _fillingCoroutine = null;
    }
}
