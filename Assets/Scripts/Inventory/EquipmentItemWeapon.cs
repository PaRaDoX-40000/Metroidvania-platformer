using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentItemWeapon : EquipmentItem, ISourceDamage
{
    [SerializeField] private List<Damage> damages = new List<Damage>();
    [SerializeField] private int _weaponsLevel = 1;

    public List<Damage> GetDamageList()
    {
        return new List<Damage>(damages);
    }

    public int GetWeaponsLevel()
    {
        return _weaponsLevel;
    }
}
