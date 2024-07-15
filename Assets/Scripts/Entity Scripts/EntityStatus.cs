using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EntityStatus : MonoBehaviour
{
    [HideInInspector] public UnityEvent<bool> OnGroundChanged;
    [HideInInspector] public UnityEvent<bool> IsMovingChanged;
    [HideInInspector] public UnityEvent<bool> IsAttackingChanged;
    [SerializeField] private Attack _attack;
    [SerializeField] private Movement _movement;
    [SerializeField] private Jump _jump;


    protected bool _onGround;
    protected bool _isMoving;
    private bool _isAttacking;
    public bool OnGround
    {
        get => _onGround; 
        set
        {
            _onGround = value;
            OnGroundChanged.Invoke(_onGround);
        }
    }
    public bool IsMoving 
    {
        get => _isMoving;
        set
        {          
            _isMoving = value;
            IsMovingChanged.Invoke(_isMoving);
        }
    }

    protected bool IsAttacking { get => _isAttacking;}

    

    private void OnEnable()
    {
        _attack.isAttackingChanged.AddListener(AttackingChanged);
        _movement.ObjectsMoving.AddListener(MovingChanged);
        _jump.OnGroundChanged.AddListener(GroundOnChanged);

    }
    private void OnDisable()
    {
        _attack.isAttackingChanged.RemoveListener(AttackingChanged);
        _movement.ObjectsMoving.RemoveListener(MovingChanged);
        _jump.OnGroundChanged.RemoveListener(GroundOnChanged);

    }

    private void AttackingChanged(bool isAttacking)
    {
        _isAttacking = isAttacking;
        IsAttackingChanged?.Invoke(_isAttacking);
    }
    private void GroundOnChanged(bool OnGround)
    {
        this.OnGround = OnGround;   
    }
    private void MovingChanged(float horizontalMoveValue)
    {
        if (horizontalMoveValue == 0)
            IsMoving = false;
        else
            IsMoving = true;
    }
}
