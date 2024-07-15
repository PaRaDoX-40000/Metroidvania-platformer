using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
    [HideInInspector] public UnityEvent<float> ObjectsMoving;
    [SerializeField] private float _speed=3f;
    [SerializeField] private float _propertySpeed;
    private IMoveInput _moveInput;
    private Rigidbody2D _rigidbody2D;
    private float _movementSpeed;
    private Vector2 _moveVector2 = Vector2.zero;


    public float MovementSpeed 
    {
        get => _movementSpeed;
        set 
        {
            _movementSpeed = value;
            ObjectsMoving.Invoke(_movementSpeed);         
        }
    }

    void Start()
    {      
        _moveInput = GetComponent<IMoveInput>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _moveInput.SubscribeOnMovementHorizontal(CheckMoveInputHorizontalValue);
    }

    void FixedUpdate()
    {
        _moveVector2.y = _rigidbody2D.velocity.y;
        _rigidbody2D.velocity = _moveVector2;     
    }

    void CheckMoveInputHorizontalValue(int horizontalMoveValue)
    {
        
        MovementSpeed = horizontalMoveValue * _speed;
        _moveVector2.x = MovementSpeed;           
    }
    public void AddPropertySpeed(float speed)
    {
        _propertySpeed += speed;
    }






}
