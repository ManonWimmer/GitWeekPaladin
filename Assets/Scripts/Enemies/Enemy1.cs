using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] Transform _crystal;
    [SerializeField] int _moveSpeed;
    [SerializeField] Collider2D _attackTrigger;
    [SerializeField] int _lifeCrystal;
    [SerializeField] public Rigidbody2D _enemy;
    [SerializeField] AttackTrigger attackTrigger;
    private void FixedUpdate()
    {
        if (attackTrigger.isMoving==true)
        {
            Vector3 direction = _crystal.position - transform.position;
            direction.Normalize();
            transform.position += direction * _moveSpeed * Time.fixedDeltaTime;
        }
        
    }
}


