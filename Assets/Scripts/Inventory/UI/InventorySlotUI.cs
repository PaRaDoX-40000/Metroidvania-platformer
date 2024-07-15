using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : SlotUI
{
    [SerializeField] private TMP_Text quantityInStack;
    [SerializeField] private Image image;

    public override void Set(ItemStack itemStack)
    {
        quantityInStack.gameObject.SetActive(true);
        image.gameObject.SetActive(true);
      
        quantityInStack.text = itemStack.QuantityInStack.ToString();
        image.sprite = itemStack.Item.Sprite;
    }
    public override void Deactivate()
    {
        quantityInStack.gameObject.SetActive(false);
        image.gameObject.SetActive(false);
    }
}
