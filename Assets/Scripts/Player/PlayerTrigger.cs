using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Damage enemy when script is done
            // collision.Enemy.Damage();
            Debug.Log($"Hit ennemy : {collision.name}");
        }
        
    }
}
