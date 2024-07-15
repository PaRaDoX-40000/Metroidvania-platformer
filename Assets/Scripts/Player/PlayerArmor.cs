using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerArmor : EntityArmor
{
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private PlayerEquipment playerEquipment;
    private EquipmentItemArmor playerArmor = null;
    public UnityEvent<int> ArmorGetDamage;
    protected override void Start()
    {        
        base.Start();
    }
    private void ArmorChange(EquipmentItem equipmentItem, EquipmentSlotType equipmentSlotType)
    {
        if(equipmentSlotType != EquipmentSlotType.Armor)
        {
            return;
        }
        if(equipmentItem == null)
        {
            _maxArmor = 0;
            _currentArmor = 0;
            _armorLevel= 0;
            if(playerArmor != null)
            {
                ArmorGetDamage.RemoveListener(playerArmor.ArmorGetDamage);
                playerArmor = null;
            }
        }
        else
        {
            EquipmentItemArmor armor = (EquipmentItemArmor)equipmentItem;
            _maxArmor = armor.MaxArmor;
            _currentArmor = armor.CurrentArmor;
            _armorLevel = armor.ArmorLevel;
            ArmorGetDamage.AddListener(armor.ArmorGetDamage);
            playerArmor = armor;
        }      
    }  

    public override void TakeDamage(Damage damage, int weaponsLevel)
    {
        base.TakeDamage(damage, weaponsLevel);
        ArmorGetDamage?.Invoke(_currentArmor);
    }
}
