using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackTrigger : MonoBehaviour
{
    [SerializeField] MovementEnemy enemy1;
    public bool isMoving;
    [SerializeField] int _timeBeforeAttack;
    [SerializeField] int _enemyForce=1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Crystal"))
        {
            StartCoroutine(CoroutineAttack());
            LifeCrystal.Instance.TakeDamage(_enemyForce);
            isMoving = false;
        }
    }

    IEnumerator CoroutineAttack()
    {
        yield return new WaitForSeconds(_timeBeforeAttack);
        LifeCrystal.Instance.TakeDamage(1);
        StartCoroutine(CoroutineAttack());
    }
}
