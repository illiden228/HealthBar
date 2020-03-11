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
    private float _currentHealth;

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
        _currentHealth = _maxHealth;
        _healthBar.value = _currentHealth / _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if(_currentHealth < 0)
        {
            _currentHealth = 0;
        }
        StartCoroutine(SetHealth());
    }

    public void TakeHill(float hill)
    {
        _currentHealth += hill;
        if(_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        StartCoroutine(SetHealth());
    }

    private IEnumerator SetHealth()
    {
        _textHealth.text = _currentHealth.ToString() + " / " + _maxHealth.ToString();
        while(_healthBar.value != _currentHealth / _maxHealth)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _currentHealth / _maxHealth, 1 / _speedChangeHealth * Time.deltaTime);
            yield return null;
        }
    }
}
