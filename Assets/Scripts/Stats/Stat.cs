using System;
using UnityEngine;


[Serializable]

public class Stat 
{
    [SerializeField] private NameStats _nameStats;
    [SerializeField] private int _valueStat;

    public NameStats StatsName { get => _nameStats;}
    public int ValueStat { get => _valueStat;}

    public enum NameStats 
    {
        MaxHealth = 0,
        MaxArmor = 1,
        BaseAttack = 2,
        Endurance = 3,
        Strength = 4,
        Dexterity = 5,
    }

    public Stat(int nameStats)
    {
        _nameStats = (NameStats)nameStats;
        _valueStat = 100;
    }

    public void AddValueStat(int valueStat)
    {
        _valueStat += valueStat;
    }
}
