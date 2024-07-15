using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private EntityHealth _health;
    [SerializeField] private EntityArmor _armor;
   
    public void TakeDamage(List<Damage> damages, int weaponsLevel)
    {
        Damage damageToArmor = damages.FirstOrDefault(q => q.TypeDamage == Damage.DamageType.damageToArmor);
        List<Damage> newDamages = new List<Damage>(damages);
        if (damageToArmor != null)
        {
            newDamages.Remove(damageToArmor);
        }
        foreach(Damage damage in newDamages)
        {
            
            int newDamage = damage.DamageAmount - (_armor.CurrentArmor + (_armor.CurrentArmor * (_armor.ArmorLevel - weaponsLevel) / 10));
            if (newDamage > 0)
            {               
                _health.TakeDamage(new Damage (damage.TypeDamage,newDamage));
            }
        }
        if (damageToArmor != null)
        {
            _armor.TakeDamage(damageToArmor, weaponsLevel);
        }

    }
}
