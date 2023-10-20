using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour
{
    [SerializeField] Collider2D _colliderBlast;
    [SerializeField] GameObject enemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("EnemyBlast"))
        {
            collision.GetComponent<LifeEnemy>().EnemyTakeBlast();
            Debug.Log("Explosion");
            StartCoroutine(CoroutineBlast());
            Destroy(enemy);
        }
    }
    IEnumerator CoroutineBlast()
    {

        yield return new WaitForSeconds(1.0f);
    }
}
