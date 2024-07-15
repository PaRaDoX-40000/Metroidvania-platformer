using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : EntityHealth
{
    [SerializeField] private PlayerStats _playerStats;
    public override void Start()
    {
        _maxHealth = _playerStats.GetStar(Stat.NameStats.MaxHealth).ValueStat;
        _playerStats.MaxHealthChanged.AddListener(ChangeMaxHealth);
        base.Start();
    }
    private void ChangeMaxHealth(int newMaxHealth)
    {
        _maxHealth= newMaxHealth;
        if(_currentHealth > _maxHealth)
        {
            _currentHealth= newMaxHealth;
        }
    }

}
