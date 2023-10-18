using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LifeEnemy : MonoBehaviour
{
    [SerializeField] int _life;
    [SerializeField] Collider2D _colliderBlast;
    bool inTrigger=false;

    public int Life { get => _life; private set => _life = value; }

    public void EnemyTakeDamage()
    {
        Life -=1 ;
        EnemyDie(Life);
    }

    void EnemyDie(int life)
    {
        if(life <= 0 && gameObject.CompareTag("EnemyBlast"))
        {
            _colliderBlast.gameObject.SetActive(true);
            if(inTrigger)
            
            Destroy(gameObject);
        }
        else if (life <= 0)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("EnemyBlast"))
        {
            collision.GetComponent<LifeEnemy>().EnemyTakeDamage();
            Debug.Log($"Hit ennemy : {collision.name}");
        }

    }
}
