using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField]AttackTrigger _attackTrigger;
    [SerializeField]GameObject _crystal;
    int _i = 0;
    int _timeBeforeAttack;
    int _oldTimeBeforeAttack;
    int _moveSpeed = 5;
    private void Awake()
    {
        if (gameObject.CompareTag("Sorcier"))
        {
            _attackTrigger.enabled = false;
        }
    }
    private void FixedUpdate()
    {
        _i++;
        if (_i == 50)
        {
            _timeBeforeAttack++;
        }
        if (_timeBeforeAttack!= _oldTimeBeforeAttack)
        {
            Vector2 direction = _crystal.transform.position - transform.position;
            if (direction.magnitude > 0.1f)
            {
                direction.Normalize();
                transform.Translate(direction * _moveSpeed * Time.deltaTime);
            }
            _oldTimeBeforeAttack = _timeBeforeAttack;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Crystal"))
        {
            Destroy(gameObject);
        }
    }
}
