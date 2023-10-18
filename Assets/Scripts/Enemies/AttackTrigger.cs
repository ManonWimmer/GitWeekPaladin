using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackTrigger : MonoBehaviour
{
    [SerializeField] MovementEnemy enemy1;
    public bool isMoving;
    [SerializeField] int timeBeforeAttack;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Crystal"))
        {
            StartCoroutine(CoroutineAttack());
            LifeCrystal.Instance.TakeDamage(1);
            isMoving = false;
        }
    }

    IEnumerator CoroutineAttack()
    {
        yield return new WaitForSeconds(timeBeforeAttack);
        LifeCrystal.Instance.TakeDamage(1);
        StartCoroutine(CoroutineAttack());
    }
}
