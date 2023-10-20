using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour
{
    [SerializeField] Collider2D _colliderBlast;
    [SerializeField] GameObject enemy;

    void OnEnable()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("EnemyBlast"))
        {
            Debug.Log("Explosion");
            collision.GetComponent<LifeEnemy>().EnemyTakeBlast();
            

        }
    }
    IEnumerator CoroutineBlast()
    {
        yield return new WaitForSeconds(1.0f);

        Destroy(enemy);
    }
}
