using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 1f;
    [SerializeField] private float _currentHealth;

    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;

    public event Action<float> IsValueChange;
    public event Action Died;

    private void OnEnable()
    {
        _currentHealth = _maxHealth;
    }

    public void Heal(float healAmount)
    {
        if (_currentHealth > 0)
        {
            if (_currentHealth + healAmount > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
            else
            {
                _currentHealth += healAmount;
            }

            IsValueChange?.Invoke(_currentHealth);
        }
    }

    public void TakeDamage(float damage)
    {
        if (_currentHealth - damage > 0)
        {
            _currentHealth -= damage;
            IsValueChange?.Invoke(_currentHealth);
        }
        else
        {
            Die();
        }
    }

    public void Die()
    {
        Died?.Invoke();
    }
}
