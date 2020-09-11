using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Slider))]
public class Health : MonoBehaviour
{
    public float _healthValue { get; private set; } = 75;
    [SerializeField] private float _maxHealthValue;
    [SerializeField] private Image _healthBarFill;
    private Slider _healthBarSlider;


    public void Awake()
    {
        _healthBarSlider = GetComponent<Slider>();
        _healthBarSlider.maxValue = _maxHealthValue;
        _healthBarSlider.value = _healthValue;
    }

    public void EffectedBySpell(Spells.Type type)
    {
        _healthValue += Spells.GetPower(type);
        if (_healthValue <= 0)
            _healthValue = 0;
        if (_healthValue > _maxHealthValue)
            _healthValue = _maxHealthValue;
        _healthBarSlider.DOValue(_healthValue, 1);
    }

    public void UpdateBarColor()
    {
        float normalHealthLimit = 0.5f;
        float lowHealthLimit = 0.2f;
        if (_healthBarSlider.value > _healthBarSlider.maxValue * normalHealthLimit)
        {
            _healthBarFill.color = Color.Lerp(Color.yellow, Color.green, (_healthBarSlider.value / _healthBarSlider.maxValue - normalHealthLimit) / normalHealthLimit);
        }
        else if (_healthBarSlider.value > _healthBarSlider.maxValue * lowHealthLimit)
        {
            _healthBarFill.color = Color.Lerp(Color.red, Color.yellow, (_healthBarSlider.value / _healthBarSlider.maxValue - lowHealthLimit) / lowHealthLimit);
        }
        else _healthBarFill.color = Color.red;
    }
}
