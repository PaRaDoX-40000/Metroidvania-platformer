using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStatus : EntityStatus
{
    [SerializeField] private Rigidbody2D _playerrigidbody2D;

    [HideInInspector] public UnityEvent<bool> isFallingChanged;

   
    private bool _isFalling;
    public bool IsFalling
    {
        get => _isFalling;
        set
        {
            _isFalling = value;
            isFallingChanged.Invoke(_isFalling);

        }
    }
    private void Update()
    {
        if(_onGround==false)
        {
            if (_playerrigidbody2D.velocity.y > 0)
            {
                IsFalling = false;
            }
            else
            {
                IsFalling= true;
            }
        }
    }
}
