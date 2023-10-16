using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi1 : MonoBehaviour
{
    [SerializeField] Transform crystal;
    [SerializeField] int _moveSpeed;
    [SerializeField]Rigidbody2D _rb;

    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        _rb.MovePosition( crystal.position * _moveSpeed * Time.fixedDeltaTime);
    }
}
