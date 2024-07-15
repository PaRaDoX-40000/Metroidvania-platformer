using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListPropertyToApply : MonoBehaviour
{
    [SerializeField] private Movement _playerMovement;
    public Movement PlayerMovement { get => _playerMovement;}
}
