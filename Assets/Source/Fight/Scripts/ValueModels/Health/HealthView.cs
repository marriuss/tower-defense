using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] private BarView _bar;

    private ITargetable _target;
    private HealthState _healthState;

    private void Awake()
    {
        _target = GetComponentInParent<ITargetable>();
    }

    private void Start()
    {
        if (_target != null)
        {
            StartCoroutine(SetLimitsWhenInitialized());
        }
    }

    private void Update()
    {
        if (_healthState != null)
        {
            _bar.SetValue(_healthState.Value);
            _bar.gameObject.SetActive(!_healthState.IsDead);
        }
    }

    private IEnumerator SetLimitsWhenInitialized()
    {
        while (_target.HealthState == null)
            yield return null;

        _healthState = _target.HealthState;
        _bar.SetLimits(new RangeInt(0, _healthState.MaxValue));
    }
}
