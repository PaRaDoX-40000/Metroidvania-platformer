using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IMoveInput 
{

    public void SubscribeOnMovementHorizontal(UnityAction<int> unityAction);
    
    public void SubscribeOnMovementVertical(UnityAction<int> unityAction);
   


    public void UnsubscribeOnMovementHorizontal(UnityAction<int> unityAction);
    
    public void UnsubscribeOnMovementVertical(UnityAction<int> unityAction);
    





}
