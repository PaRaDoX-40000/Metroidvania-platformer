using System.Collections.Generic;
using UnityEngine;



public class EquipmentItem : Item
{
    [SerializeField] private List<Stat> statList = new List<Stat>();
    [SerializeField] private EquipmentSlotType equipmentSlotType;
    [SerializeField] private List<ItemProperty> properties = new List<ItemProperty>();
    public EquipmentSlotType EquipmentSlotType { get => equipmentSlotType;}
    public List<Stat> GetStatList()
    {
        return new List<Stat>(statList);
    }  
    public void EnableProperty(ListPropertyToApply listPropertyToApply)
    {
        foreach(ItemProperty property in properties)
        {
            property.EnableProperty(listPropertyToApply);
        }
    }
    public void DisableProperty(ListPropertyToApply listPropertyToApply)
    {
        foreach (ItemProperty property in properties)
        {
            property.DisableProperty(listPropertyToApply);
        }
    }
    public override bool CanEquip()
    {
        return true;
           
    }
}
