using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDamageSourceSeter : MonoBehaviour
{
    [SerializeField] private PlayerEquipment _playerEquipment;
    [SerializeField] private DamageDoer _playerDamageDoer;
    [SerializeField] private EquipmentItemWeapon DefoltWeapon;

    private void Start()
    {
        _playerDamageDoer.SetSourceDamage(DefoltWeapon);
    }
    private void OnEnable()
    {
        _playerEquipment.ItemChange.AddListener(ItemEqup);
    }
    private void OnDisable()
    {
        _playerEquipment.ItemChange.RemoveListener(ItemEqup);
    }

    private void ItemEqup(EquipmentItem equipmentItem,EquipmentSlotType equipmentSlotType)
    {
        if(equipmentSlotType != EquipmentSlotType.Weapon)
        {
            return;
        }
        _playerDamageDoer.SetSourceDamage((EquipmentItemWeapon)equipmentItem);
        
    }
}
