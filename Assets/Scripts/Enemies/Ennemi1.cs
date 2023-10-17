using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Ennemi1 : MonoBehaviour
{
    [SerializeField] Transform crystal;
    [SerializeField] int _moveSpeed;
    [SerializeField] Collider2D zoneAttack;
    [SerializeField] int vieCrystal;
    private void FixedUpdate()
    {
        Vector3 direction = crystal.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
        transform.position += direction * _moveSpeed * Time.fixedDeltaTime;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        vieCrystal -= 1;
    }
}


