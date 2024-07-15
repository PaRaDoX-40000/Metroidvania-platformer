using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlotUI : SlotUI
{
    [SerializeField] private Image image;
    public override void Set(ItemStack itemStack)
    {        
        image.gameObject.SetActive(true);
        
        image.sprite = itemStack.Item.Sprite;
    }
    public override void Deactivate()
    {      
        image.gameObject.SetActive(false);
    }
}
