using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDoer : MonoBehaviour
{
    [SerializeField] private ISourceDamage _sourceDamage;
    [SerializeField] private HitHandler _hitHandler;


    private void Start()
    {
        _hitHandler.HittingTarget.AddListener(DoDamage);
    }
    private void DoDamage(DamageController damageController)
    {
        damageController.TakeDamage(_sourceDamage.GetDamageList(),_sourceDamage.GetWeaponsLevel());      
    }

    public void SetSourceDamage(ISourceDamage sourceDamage)
    {
        _sourceDamage = sourceDamage;
        
    }
}
