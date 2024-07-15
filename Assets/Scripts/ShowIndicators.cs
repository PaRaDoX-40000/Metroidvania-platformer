using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowIndicators : MonoBehaviour
{
    [SerializeField] private EntityArmor entityArmor;
    [SerializeField] private EntityHealth entityHealth;
    [SerializeField] private Transform Health;
    [SerializeField] private Transform Armor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Health.localScale = new Vector3( (float)entityHealth.CurrentHealth/100f,Health.localScale.y,Health.localScale.z);
        Armor.localScale = new Vector3((float)entityArmor.CurrentArmor/40f, Armor.localScale.y, Armor.localScale.z);

    }
}
