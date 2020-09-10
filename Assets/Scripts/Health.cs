using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Slider))]
public class Health : MonoBehaviour
{
    public float _value { get; private set; } = 75;
    [SerializeField] private float _maxValue;
    [SerializeField] private Image _fill;
    private Slider _slider;


    public void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _maxValue;
        _slider.value = _value;
    }

    public void EffectedBySpell(Spells.Type type)
    {
        _value += Spells.GetPower(type);
        if (_value <= 0)
            _value = 0;
        if (_value > _maxValue)
            _value = _maxValue;
        _slider.DOValue(_value, 1);
    }

    public void UpdateBarColor()
    {
        float normalHealthLimit = 0.5f;
        float lowHealthLimit = 0.2f;
        if (_slider.value > _slider.maxValue * normalHealthLimit)
        {
            _fill.color = Color.Lerp(Color.yellow, Color.green, (_slider.value / _slider.maxValue - normalHealthLimit) / normalHealthLimit);
        }
        else if (_slider.value > _slider.maxValue * lowHealthLimit)
        {
            _fill.color = Color.Lerp(Color.red, Color.yellow, (_slider.value / _slider.maxValue - lowHealthLimit) / lowHealthLimit);
        }
        else _fill.color = Color.red;
    }
}
