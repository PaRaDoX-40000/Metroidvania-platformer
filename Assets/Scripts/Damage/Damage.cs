using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Damage
{
    [SerializeField] private DamageType _damageType;
    [SerializeField] private int _damageAmount;

    public DamageType TypeDamage { get => _damageType;}
    public int DamageAmount { get => _damageAmount;}

    public enum DamageType
    {
        damageToArmor = 0,
        crushing = 1,
        stabbing = 2,
        cutting = 3,
    }
    public Damage (DamageType damageType, int damageAmount)
    {
        _damageType = damageType;
        _damageAmount = damageAmount;
    }
}
