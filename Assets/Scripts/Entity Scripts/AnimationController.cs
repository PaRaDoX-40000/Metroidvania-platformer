using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerStatus _playerStatus;
    

    private void OnEnable()
    {
        _playerStatus.OnGroundChanged.AddListener(SetOnGround);
        _playerStatus.IsMovingChanged.AddListener(SetOsMoving);
        _playerStatus.isFallingChanged.AddListener(SetIsFalling);
        _playerStatus.IsAttackingChanged.AddListener(SetIsAttacking);
    }
    private void OnDisable()
    {
        _playerStatus.OnGroundChanged.RemoveListener(SetOnGround);
        _playerStatus.IsMovingChanged.RemoveListener(SetOsMoving);
        _playerStatus.isFallingChanged.RemoveListener(SetIsFalling);
        _playerStatus.IsAttackingChanged.RemoveListener(SetIsAttacking);

    }

    void SetOnGround (bool onGround)
    {
        _animator.SetBool("onGround", onGround);
    }
    void SetOsMoving(bool isMoving)
    {
       
        if (isMoving)
        {
            _animator.SetFloat("isMoving", 1);
        }
        else 
        {
            _animator.SetFloat("isMoving", 0);

        }

    }
    void SetIsFalling(bool isFalling)
    {
        _animator.SetBool("isFalling", isFalling);
    }

    private void SetIsAttacking(bool IsAttacking)
    {
        _animator.SetBool("IsAttacking", IsAttacking);
    }
}
