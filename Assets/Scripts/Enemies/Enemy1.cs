using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] int _moveSpeed;
    [SerializeField] Collider2D _attackTrigger;
    [SerializeField] int _lifeCrystal;
    [SerializeField] Rigidbody2D _enemy;
    [SerializeField] AttackTrigger attackTrigger;
    private void FixedUpdate()
    {
        if (attackTrigger.isMoving)
        {
            Vector3 direction = LifeCrystal.Instance.transform.position - transform.position;
            direction.Normalize();
            transform.position += direction * _moveSpeed * Time.fixedDeltaTime;
            if (direction.x > 0)
            {
                _attackTrigger.offset = new Vector2(0.7f,0);
            }
            
        }
        if (attackTrigger.isMoving == false)
        {
            _enemy.constraints= RigidbodyConstraints2D.FreezeAll;
        }


    }
}


