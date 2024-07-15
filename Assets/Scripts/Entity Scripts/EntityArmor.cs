using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EntityArmor : MonoBehaviour
{
    [SerializeField] protected int _maxArmor;
    [SerializeField] protected int _armorLevel = 1;
    protected int _currentArmor;
    public UnityEvent ArmorDroken;

    public int CurrentArmor { get => _currentArmor;}
    public int ArmorLevel { get => _armorLevel;}

    
    protected virtual void Start()
    {
        _currentArmor = _maxArmor;
    }

    public virtual void TakeDamage(Damage damage, int weaponsLevel)
    {
        if (damage.DamageAmount < 0)
        {
            return;
        }
        int newDamage = damage.DamageAmount + damage.DamageAmount * (weaponsLevel - _armorLevel) /10;
        if (_currentArmor - newDamage < 0)
        {
            _currentArmor = 0;
        }
        else
        {
            _currentArmor -= newDamage;
        }
        if (_currentArmor == 0)
        {
            ArmorDroken?.Invoke();
        }
    }
}
