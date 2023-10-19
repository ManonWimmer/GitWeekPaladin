using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour
{
    [SerializeField] Collider2D _colliderBlast;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("EnemyBlast"))
        {
            collision.GetComponent<LifeEnemy>().EnemyTakeDamage();
            Debug.Log("Explosion");
        }

    }

}
