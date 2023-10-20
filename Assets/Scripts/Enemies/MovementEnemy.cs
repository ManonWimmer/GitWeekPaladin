using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class MovementEnemy : MonoBehaviour
{
    [SerializeField] int _moveSpeed;
    [SerializeField] Collider2D _trigger;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] AttackTrigger _attackTriggerScript;
    [SerializeField] GameObject _fireBall;

    private bool _isFacingRight = false;
    [SerializeField] SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _fireBall.SetActive(false);
    }

    // Anim :
    [SerializeField] Animator _anim;
    private void FixedUpdate()
    {
        if (_attackTriggerScript.isMoving)
        {
            Vector3 direction = LifeCrystal.Instance.transform.position - transform.position;
            direction.Normalize();
            transform.position += direction * _moveSpeed * Time.fixedDeltaTime;
            if (direction.x > 0)
            {
                _trigger.offset = new Vector2(0.7f, 0);
                _spriteRenderer.flipX = false;
            }
        }
        if (_attackTriggerScript.isMoving == false)
        {
            _rb.constraints = RigidbodyConstraints2D.FreezeAll;
            _fireBall.SetActive(true);

        }
    }

    private void Update()
    {
        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        if (gameObject.CompareTag("EnemyBlast"))
        {
            _anim.SetBool("isExploding", _attackTriggerScript.IsExploded);
        }

        _anim.SetBool("isDead", _attackTriggerScript.IsDead);
    }
}

