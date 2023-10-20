using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackTrigger : MonoBehaviour
{
    public bool isMoving;

    [SerializeField] GameObject _enemy;
    [SerializeField] GameObject _prefabFireBall;
    [SerializeField] int _enemyForce = 1;
    public bool IsDead = false;
    [SerializeField] float _animationDeadTime;
    [SerializeField] float _animationExplosionTime = 0.85f;

    [SerializeField] LifeEnemy _lifeEnemy;

    public bool IsExploded = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Crystal"))
        {
            
            LifeCrystal.Instance.TakeDamage(_enemyForce);

            if (transform.parent.CompareTag("EnemyBlast"))
            {
                StartCoroutine(ExplosionDelay());
            }

            else if(transform.parent.CompareTag("Sorcier"))
            {
                StartCoroutine(AttackSorcier());
            }
            else
            {
                StartCoroutine(DeadDelay());

            }
            isMoving = false;
        }
    }

    public IEnumerator ExplosionDelay()
    {
        IsExploded = true;
        isMoving = false;
        yield return new WaitForSeconds(_animationExplosionTime);
        _lifeEnemy.blast = true;
        IsExploded = false;
        yield return StartCoroutine(DeadDelay());
    }
    
    public IEnumerator AttackSorcier()
    {

        GameObject obj = Instantiate(_prefabFireBall,transform.position,Quaternion.identity);
        obj.transform.SetParent(transform.parent);
        yield return new WaitForSeconds(2.0f);
        yield return StartCoroutine(AttackSorcier());
    }

    public IEnumerator DeadDelay()
    {
        IsDead = true;
        isMoving = false;
        IsExploded = false;
        yield return new WaitForSeconds(_animationDeadTime);
        Destroy(_enemy);
    }
}
