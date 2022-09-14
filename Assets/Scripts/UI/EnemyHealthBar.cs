using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : Bar
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Image _fill;

    private void OnEnable()
    {
        _enemy.HealthChanged += OnValueChanged;
        Slider.value = 1;
    }

    private void OnDisable()
    {
        _enemy.HealthChanged -= OnValueChanged;
    }

    public override void OnValueChanged(int value, int maxValue)
    {
        base.OnValueChanged(value, maxValue);
        ColorChange(Slider.value);
    }

    private void ColorChange(float sliderValue)
    {
        if (sliderValue <= 0.6f && sliderValue > 0.3f)
            _fill.color = Color.yellow;
        else if (sliderValue <= 0.3f)
            _fill.color = Color.red;
    }
}
