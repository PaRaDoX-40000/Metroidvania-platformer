using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TurningModelInDirectionOfMovement : MonoBehaviour
{
    [SerializeField] private GameObject _model;
    [SerializeField] private Movement _movement;
    void Start()
    {
        _movement.ObjectsMoving.AddListener(CheckMovementSpeedValue);
    }

    void CheckMovementSpeedValue(float MovementSpeed)
    {
        if (MovementSpeed > 0)
        {
            _model.transform.localScale = new Vector3(1, 1, 1); 
        }
        if(MovementSpeed < 0)
        {
            _model.transform.localScale = new Vector3(1, 1, -1);


        }
    }

}
