using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    int _i = 0;
    int _timeBeforeAttack;
    int _oldTimeBeforeAttack;
    int _moveSpeed = 5;
    [SerializeField] int _damageFireBall=1;


    private void FixedUpdate()
    {
        Vector2 direction = LifeCrystal.Instance.transform.position - transform.position;
        if (direction.magnitude > 0.1f)
        {
            direction.Normalize();
            transform.Translate(direction * _moveSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Crystal"))
        {
            LifeCrystal.Instance.TakeDamage(_damageFireBall);
            Destroy(gameObject);
        }
    }
}
