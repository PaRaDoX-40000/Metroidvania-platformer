using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SlotUI : MonoBehaviour
{
    public abstract void Set(ItemStack itemStack);
    public abstract void Deactivate();
}
