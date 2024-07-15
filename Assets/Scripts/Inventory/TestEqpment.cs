using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEqpment : MonoBehaviour
{

    
    [SerializeField] Inventory inventory;
    [SerializeField] List<Item> items;
   
    void Start()
    {
       
        foreach ( Item item in items) 
        {
            
            inventory.AddItem(item);
        }
    }

    //public void Add()
    //{
    //    inventory.AddItemStack(new ItemStack(item,1));
    //}


}
