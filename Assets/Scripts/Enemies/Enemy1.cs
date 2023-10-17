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
    private void FixedUpdate()
    {
        Vector3 direction = _crystal.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
        transform.position += direction * _moveSpeed * Time.fixedDeltaTime;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        _lifeCrystal -= 1;
    }
}


