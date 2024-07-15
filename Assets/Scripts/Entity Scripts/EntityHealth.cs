using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EntityHealth : MonoBehaviour
{
    [SerializeField] protected int _maxHealth;
    protected int _currentHealth;
    public UnityEvent EntityDead;

    public int CurrentHealth { get => _currentHealth; }

    public virtual void Start()
    {
        _currentHealth = _maxHealth;
        
    }

    public virtual void TakeDamage(Damage damage) 
    {
        if(_currentHealth - damage.DamageAmount < 0)
        {
            _currentHealth = 0;
        }
        else
        {
            _currentHealth -= damage.DamageAmount;
        }
        if(_currentHealth == 0)
        {
            EntityDead?.Invoke();
        }
    }
}
