using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Attack : MonoBehaviour
{
    [SerializeField] private Vector3 positionHitColllider;
    [SerializeField] private Collider2D _hitColllider;
    [SerializeField] private float _attackTime = 0.5f;
    [HideInInspector] public UnityEvent<bool> isAttackingChanged;
    private bool _attacking = false;

    private bool Attacking { get => _attacking; set {_attacking = value; isAttackingChanged?.Invoke(_attacking); } }
   
    private void Start()
    {
        _hitColllider.transform.localPosition = positionHitColllider;
        _hitColllider.enabled= false;
    }
    private void Update() // перенести в инпут
    {
        if (Input.GetAxis("Attack") > 0)
        {
            if(_attacking == false)
            {
                StartCoroutine(DoHit());
            }
        }
    }
    IEnumerator DoHit()
    {
        _hitColllider.enabled= true;
        Attacking = true;
        yield return new WaitForSeconds(_attackTime);
        Attacking = false;
        _hitColllider.enabled = false;
    }
}
