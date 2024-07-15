using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using UnityEditorInternal.Profiling.Memory.Experimental;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int _maxSlots=10;
    
    [SerializeField] private List<InventorySlot> _inventorySlots;
    [SerializeField] private List<EquipmentSlot> _equipmentSlots;
    [SerializeField] private PlayerEquipment _playerEquipment;
    private ItemStack _itemOnNand = null;

    public int MaxSlots { get => _maxSlots; }
    public UnityEvent<int, ItemStack> ItemInInventorySlotChanged;
    public UnityEvent<int, EquipmentItem> ItemInEquipmenSlotChanged;
    public UnityEvent<ItemStack> ItemOnNandChanged;  




    private void Awake()
    {       
        foreach(InventorySlot inventorySlot in _inventorySlots)
        {
            inventorySlot.SlotWasClicked.AddListener(SlotWasClicked);
        }
        foreach (EquipmentSlot _equipmentSlot in _equipmentSlots)
        {
            _equipmentSlot.SlotWasClicked.AddListener(EquipmentSlotWasClicked);
        }

    }
    void EquipmentSlotWasClicked(EquipmentSlot equipmentSlot)
    {
        
        _playerEquipment.EquipItem(ref _itemOnNand, equipmentSlot);
        int index = _equipmentSlots.IndexOf(equipmentSlot);        
        ItemInEquipmenSlotChanged?.Invoke(index, equipmentSlot.GetEquipmentItem());
        ItemOnNandChanged?.Invoke(_itemOnNand);
    }
    void SlotWasClicked (InventorySlot inventorySlot)
    {
        int index = _inventorySlots.IndexOf(inventorySlot);
        ItemStack slotsItemStack = _inventorySlots[index].GetItemStack();
        _inventorySlots[index].SetItemStack(null);
        if (slotsItemStack == null && _itemOnNand == null)// нажатие на пустой слот
        {
           
            return;
            
        }
        if(slotsItemStack != null && _itemOnNand == null)// взяте предмет из слота
        {
            _itemOnNand = slotsItemStack;
            ItemInInventorySlotChanged.Invoke(index,null);
            ItemOnNandChanged.Invoke(slotsItemStack);
          
            return;

        }
        if (slotsItemStack == null && _itemOnNand != null)// положить предмет в слот
        {
            ItemInInventorySlotChanged.Invoke(index, _itemOnNand);
            _inventorySlots[index].SetItemStack(_itemOnNand);
            _itemOnNand = null;           
            ItemOnNandChanged.Invoke(null);

            
            return;

        }
        if (slotsItemStack != null && _itemOnNand != null)// пеменять предмет из слота в руку
        {
            if(slotsItemStack.Item == _itemOnNand.Item)
            {
                if(slotsItemStack.QuantityInStack+ _itemOnNand.QuantityInStack <= _itemOnNand.Item.MaxStack)
                {
                    slotsItemStack.AddToQuantityInStack(_itemOnNand.QuantityInStack);
                    _inventorySlots[index].SetItemStack(slotsItemStack);
                    _itemOnNand = null;
                    ItemInInventorySlotChanged.Invoke(index, slotsItemStack);
                    ItemOnNandChanged.Invoke(_itemOnNand);
                }
                else
                {
                    _itemOnNand.AddToQuantityInStack(-(_itemOnNand.Item.MaxStack- slotsItemStack.QuantityInStack));
                    slotsItemStack.AddToQuantityInStack(_itemOnNand.Item.MaxStack - slotsItemStack.QuantityInStack);
                    _inventorySlots[index].SetItemStack(slotsItemStack);
                    ItemInInventorySlotChanged.Invoke(index, slotsItemStack);
                    ItemOnNandChanged.Invoke(_itemOnNand);
                }
            }
            else
            {
                ItemInInventorySlotChanged.Invoke(index, _itemOnNand);
                ItemOnNandChanged.Invoke(slotsItemStack);
                _inventorySlots[index].SetItemStack(_itemOnNand);
                _itemOnNand = slotsItemStack;
            }
            
           
            return;

        }

    }



    public void AddItem(Item Newitem)
    {
        
        ItemStack itemStack = new ItemStack(Newitem);        
        AddItemStack(itemStack);
    }
    public void AddItemStack(ItemStack itemStack)
    {
        InventorySlot inventorySlot = null;
        foreach(var slot in _inventorySlots) 
        {
            if (slot.ItemStackIsNull() != true)
            {
                if( slot.GetItemStack().Item == itemStack.Item)
                {
                    if(slot.GetItemStack().Item.MaxStack > slot.GetItemStack().QuantityInStack)
                    {
                        inventorySlot = slot;
                    }
                }
            }
        }

        if(inventorySlot != null)
        {
            AddItemsToExistingStack(inventorySlot, itemStack);
            
        }
        else
        {
            
            AddNewItem(itemStack);
        }
        
    }

    private void AddItemsToExistingStack(InventorySlot inventorySlot, ItemStack itemStack) //добовление придметав в стак
    {
        int index = _inventorySlots.IndexOf(inventorySlot);
        int maxStack = itemStack.Item.MaxStack;
        int inventorySlotQuantityInStack = inventorySlot.GetItemStack().QuantityInStack;
        int quantityInStack = inventorySlotQuantityInStack + itemStack.QuantityInStack;
        if(maxStack >= quantityInStack)
        {
            inventorySlot.GetItemStack().AddToQuantityInStack(itemStack.QuantityInStack);
            ItemInInventorySlotChanged.Invoke(index, inventorySlot.GetItemStack());

        }
        else
        {
            ItemInInventorySlotChanged.Invoke(index, new ItemStack(itemStack.Item, itemStack.Item.MaxStack));
            int remainder = maxStack - inventorySlotQuantityInStack;
            inventorySlot.GetItemStack().AddToQuantityInStack(remainder);
            ItemInInventorySlotChanged.Invoke(index, inventorySlot.GetItemStack());
            AddNewItem(new ItemStack(itemStack.Item, itemStack.QuantityInStack - remainder));
        }
    }

    private void AddNewItem(ItemStack itemStack)//добавлениее новых придметов
    {

        while(true) 
        {
            InventorySlot inventorySlot = _inventorySlots.FirstOrDefault(p => p.ItemStackIsNull() == true);
            int index = _inventorySlots.IndexOf(inventorySlot);

            if (inventorySlot == null)
            {
                return;
            }
            if (itemStack.QuantityInStack <= itemStack.Item.MaxStack)
            {
                ItemInInventorySlotChanged.Invoke(index, itemStack);
                inventorySlot.SetItemStack(itemStack);
                return;
            }
            else
            {
               
                inventorySlot.SetItemStack(new ItemStack(itemStack.Item, itemStack.Item.MaxStack));
                itemStack.AddToQuantityInStack(-itemStack.Item.MaxStack);
                ItemInInventorySlotChanged.Invoke(index, inventorySlot.GetItemStack());
            }

        }

    }
}
