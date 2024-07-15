using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitHandler : MonoBehaviour
{
    [HideInInspector] public UnityEvent<DamageController> HittingTarget;    
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<DamageController>(out DamageController damageController))
        {
            HittingTarget?.Invoke(damageController);
        }
    }
}
