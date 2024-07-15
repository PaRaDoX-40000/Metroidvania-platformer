using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISourceDamage
{
    abstract List<Damage> GetDamageList();
    abstract int GetWeaponsLevel();

}
