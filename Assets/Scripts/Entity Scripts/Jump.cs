using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Jump : MonoBehaviour 
{
    [HideInInspector] public UnityEvent<bool> OnGroundChanged;
    [SerializeField] private LayerMask _layerMaskGround;
    [SerializeField] private float _forceJump=1;
    [SerializeField] private float _checkingDistance = 0.1f;
    private IMoveInput _moveInput;
    private Rigidbody2D _rigidbody2D;       
    private bool _canJump = true;
    private int _verticalMoveValue;
    private bool _onGround = false;

    private bool OnGround { get => _onGround; 
        set 
        {
            if (_onGround != value)
            {
                _onGround = value;
                OnGroundChanged?.Invoke(_onGround);
            }
        } 
    }

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _moveInput = GetComponent<IMoveInput>();       
        _moveInput.SubscribeOnMovementVertical(CheckMoveInputVerticalValue);
    }

    
    void Update()
    {      
        var hit = Physics2D.Raycast(transform.position, Vector2.down, _checkingDistance, _layerMaskGround);
        OnGround = hit.collider != null;
       
    }

    void CheckMoveInputVerticalValue(int verticalMoveValue) 
    {
        _verticalMoveValue=verticalMoveValue;
        if (verticalMoveValue > 0 & _onGround == true & _canJump == true) 
        {
            _rigidbody2D.AddForce(Vector2.up * 4, ForceMode2D.Impulse);
            StartCoroutine(HighJump()); 
            StartCoroutine(Timer());
        }
       
    }

    private IEnumerator Timer()
    {
        _canJump=false;
        yield return new WaitForSeconds(0.1f);
        _canJump = true;
    }

    private IEnumerator HighJump() 
    {
        float time = 0;
        while (_verticalMoveValue > 0 & time < 0.5f)
        {
            _rigidbody2D.AddForce(Vector2.up * _forceJump, ForceMode2D.Impulse);
            time += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

    }
}
