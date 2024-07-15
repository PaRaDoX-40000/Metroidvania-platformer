
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemProperty : MonoBehaviour
{
    public abstract void EnableProperty(ListPropertyToApply listPropertyToApply);
	public abstract void DisableProperty(ListPropertyToApply listPropertyToApply);	
}
