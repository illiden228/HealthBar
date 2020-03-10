using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _textHealth;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _speedChangeHealth;

    private Slider _healthBar;
    private float _previousHealth;
    private float _currentHealth;

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
        _currentHealth = _maxHealth;
        _healthBar.value = _currentHealth / _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _previousHealth = _currentHealth;
        _currentHealth -= damage;
        if(_currentHealth < 0)
        {
            _currentHealth = 0;
        }
        StartCoroutine(DrawHealth());
    }

    public void TakeHill(float hill)
    {
        _previousHealth = _currentHealth;
        _currentHealth += hill;
        if(_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        StartCoroutine(DrawHealth());
    }

    private IEnumerator DrawHealth()
    {
        _textHealth.text = _currentHealth.ToString() + " / " + _maxHealth.ToString();
        float previous = _previousHealth / _maxHealth;
        float current = _currentHealth / _maxHealth;
        float speedChange = 1 / _speedChangeHealth;
        float delta = (current - previous) * speedChange;
        for (int i = 0; i < _speedChangeHealth; i++)
        {
            _healthBar.value += delta;
            yield return null;
        }
    }
}
