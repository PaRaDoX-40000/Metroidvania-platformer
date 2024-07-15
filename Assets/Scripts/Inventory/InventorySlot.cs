using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    
    [SerializeField] private ItemStack _itemStack;
    public UnityEvent<InventorySlot> SlotWasClicked;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ButtonClick);
    }
    void ButtonClick() 
    {
        SlotWasClicked.Invoke(this);
    }
    public ItemStack GetItemStack()
    {                                  
            return _itemStack;           
    }
    public bool ItemStackIsNull()
    {
        return _itemStack == null;
    }
    public ItemStack SetItemStack(ItemStack NewitemStack)
    {
        ItemStack itemStack = GetItemStack();
        _itemStack = NewitemStack;      
        return itemStack;
    }
}

