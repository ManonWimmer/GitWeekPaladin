using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<LifeEnemy>().EnemyTakeDamage();
            Debug.Log($"Hit ennemy : {collision.name}");
        }
        
    }
}
