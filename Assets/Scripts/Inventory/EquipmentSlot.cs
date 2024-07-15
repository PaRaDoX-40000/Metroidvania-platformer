using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    public UnityEvent<EquipmentSlot> SlotWasClicked;
    [SerializeField] private EquipmentSlotType _slotType;
    [SerializeField] private EquipmentItem _equipmentItem;

    public EquipmentSlotType SlotType { get => _slotType;}

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ButtonClick);
    }
    void ButtonClick()
    {
        SlotWasClicked.Invoke(this);
    }
    public void SetEquipmentItem(EquipmentItem equipmentItem)
    {
        if(_equipmentItem == null)
        {
            _equipmentItem = equipmentItem;
        }
        else
        {
            Debug.LogError("Ёкипированный  слот зан€т");
        }
    }
    public EquipmentItem TakeEquipmentItem() 
    {
        if(_equipmentItem != null)
        {
            EquipmentItem itemequipmentItem = _equipmentItem;
            _equipmentItem = null;
            return itemequipmentItem;
        }
        return null;     
    }
    public EquipmentItem GetEquipmentItem()
    {      
        return _equipmentItem;
    }
}
