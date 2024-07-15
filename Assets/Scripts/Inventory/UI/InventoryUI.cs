using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private List<SlotUI> inventorySlotUIs= new List<SlotUI>();
    [SerializeField] private List<SlotUI> equipmentSlotUI = new List<SlotUI>();
    [SerializeField] private InventorySlotUI _itemOnNandUI;
    [SerializeField] private RectTransform _canvasTransform;
    [SerializeField] private RectTransform _itemOnHandRT;
    private Coroutine _showItrmOnHend = null;
    private void Awake()
    {
        _inventory.ItemInInventorySlotChanged.AddListener(SetInventorySlotUI);
        _inventory.ItemInEquipmenSlotChanged.AddListener(SetEquipmentSlotUI);
        _inventory.ItemOnNandChanged.AddListener(SetItemOnNand);
    }
    void Start()
    {
        foreach(InventorySlotUI inventorySlotUI in inventorySlotUIs)
        {
            inventorySlotUI.gameObject.SetActive(false);
        }
        for (int i =0; i < _inventory.MaxSlots; i++)
        {
            inventorySlotUIs[i].gameObject.SetActive(true);
        }
       

    }
    void SetEquipmentSlotUI(int index, EquipmentItem equipmentItem)
    {
        if(equipmentItem == null) 
        {
            SetSlotUI(index, null, equipmentSlotUI);
        }
        else
        {
            ItemStack itemStack= new ItemStack(equipmentItem);
            SetSlotUI(index, itemStack, equipmentSlotUI);
        }
        
    }
    void SetInventorySlotUI(int index, ItemStack itemStack)
    {
        SetSlotUI(index, itemStack, inventorySlotUIs);
    }
    void SetSlotUI(int index, ItemStack itemStack, List<SlotUI> slotUIs)
    {
        if (itemStack != null)
        {
            slotUIs[index].Set(itemStack);
        }
        else
        {
            slotUIs[index].Deactivate();
        }
    }
    void SetItemOnNand(ItemStack itemStack)
    {
        if(itemStack != null)
        {
            _itemOnNandUI.Set(itemStack);
            if(_showItrmOnHend == null)
            {
                _showItrmOnHend = StartCoroutine(ShowItrmOnHend());
            }
        }
        else
        {
            _itemOnNandUI.Deactivate();
            if (_showItrmOnHend != null)
            {
               StopCoroutine(_showItrmOnHend);
                _showItrmOnHend= null;
            }
        }
    }
    IEnumerator ShowItrmOnHend()// добавить упровленияе для геймпада
    {
        while (true)
        {
            Vector2 mousePosition = Input.mousePosition;
            Vector2 vector2 = new Vector2(mousePosition.x/Screen.width, mousePosition.y/Screen.height);
            vector2.y -= 0.06f;
            vector2.x += 0.025f;
            vector2 = new Vector2(vector2.x*Screen.width, vector2.y* Screen.height);
           

            RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasTransform, vector2, null, out Vector2 vector21);

            _itemOnHandRT.anchoredPosition= vector21;
            yield return new WaitForEndOfFrame();
        }
    }
}
