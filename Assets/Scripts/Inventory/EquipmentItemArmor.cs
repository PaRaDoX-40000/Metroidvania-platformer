using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class EquipmentItemArmor : EquipmentItem
{  
    [SerializeField] private int _maxArmor = 100;
    [SerializeField] private int _currentArmor = 100;
    [SerializeField] private int _armorLevel = 1;

    public int MaxArmor { get => _maxArmor;}
    public int CurrentArmor { get => _currentArmor;}
    public int ArmorLevel { get => _armorLevel;}
    public void ArmorGetDamage(int currentArmor)
    {
        _maxArmor = currentArmor;
    }
    public void ArmorGetRecovery(int recovery) //подумать
    {
        if (recovery < 0)
        {
            return;
        }
        if (_maxArmor + recovery < 100)
        {
            _maxArmor = 100;
        }
        else
        {
            _maxArmor += recovery;
        }
    }
}
