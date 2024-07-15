using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Progress;

public class PlayerEquipment : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private ListPropertyToApply _listPropertyToApply;
    [HideInInspector] public UnityEvent<EquipmentItem, EquipmentSlotType> ItemChange;
    
    public void EquipItem(ref ItemStack itemStackOnNand ,EquipmentSlot equipmentSlot)
    {
        EquipmentItem item = null;
        if (itemStackOnNand != null)
        {
            if (itemStackOnNand.Item.CanEquip() == true)
            {             
                item = (EquipmentItem)itemStackOnNand.Item;
            }
            else
            {
                return;
            }
            if (equipmentSlot.SlotType != item.EquipmentSlotType)
            {
                return;
            }
            EquipmentItem equipmentItem = DesequipingItem(equipmentSlot);
            equipmentSlot.SetEquipmentItem(item);
            _playerStats.AddValueStats(item.GetStatList());
            item.EnableProperty(_listPropertyToApply);
            ItemChange?.Invoke(item, equipmentSlot.SlotType);
            if (equipmentItem == null)
            {
                itemStackOnNand = null;
            }
            else
            {
                itemStackOnNand = new ItemStack(equipmentItem);
            }
        }
        else
        {
            EquipmentItem equipmentItem = DesequipingItem(equipmentSlot);
            if (equipmentItem == null)
            {
                return;
            }
            itemStackOnNand = new ItemStack(equipmentItem);
        }
    }
    public EquipmentItem DesequipingItem(EquipmentSlot equipmentSlot) 
    {
        EquipmentItem equipmentItem = equipmentSlot.TakeEquipmentItem();
        if (equipmentItem != null)
        {
            _playerStats.SubtractValueStats(equipmentItem.GetStatList());
            equipmentItem.DisableProperty(_listPropertyToApply);
            ItemChange?.Invoke(null, equipmentSlot.SlotType);
        }
        return equipmentItem;
    }
}
