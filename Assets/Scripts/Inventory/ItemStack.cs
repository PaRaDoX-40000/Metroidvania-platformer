using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStack
{
    private Item _item;
    private int _quantityInStack;

    public Item Item { get => _item;}
    public int QuantityInStack { get => _quantityInStack;}

    public ItemStack(Item item, int quantityInStack)
    {
        _item = item;
        _quantityInStack = quantityInStack;
    }
    public ItemStack(Item item)
    {
        _item = item;
        _quantityInStack = 1;
    }
    public void AddToQuantityInStack(int value)
    {
        _quantityInStack += value;
    }
}
