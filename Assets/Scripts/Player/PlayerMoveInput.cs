using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMoveInput : MonoBehaviour, IMoveInput
{
    [HideInInspector] public UnityEvent<int> MovementHorizontal;
    [HideInInspector] public UnityEvent<int> MovementVertical;
    [HideInInspector] public UnityEvent MovementUp;
    private int _horizontal;
    private int _vertical;

    private int Vertical { get => _vertical;
        set 
        {
            if (_vertical != value)
            {
                _vertical = value;
                MovementVertical.Invoke(_vertical);
                
            }
        } 
    }

    private int Horizontal
    {
        get => _horizontal;
        set
        {
            if(_horizontal != value) 
            {
                _horizontal = value;
                MovementHorizontal.Invoke(_horizontal);
                
            }          
        }
    }

    public void SubscribeOnMovementHorizontal(UnityAction<int> unityAction)
    {
        MovementHorizontal.AddListener(unityAction);
    }
    public void SubscribeOnMovementVertical(UnityAction<int> unityAction)
    {
        MovementVertical.AddListener(unityAction);
        
    }
    
    public void UnsubscribeOnMovementHorizontal(UnityAction<int> unityAction)
    {
        MovementHorizontal.RemoveListener(unityAction);
    }  
    public void UnsubscribeOnMovementVertical(UnityAction<int> unityAction)
    {
        MovementVertical.RemoveListener(unityAction);
    }
   

   

    // Update is called once per frame
    void Update()
    {
        Vertical = (int)Input.GetAxis("Vertical");
        Horizontal = (int)Input.GetAxis("Horizontal");
        
    }
}
