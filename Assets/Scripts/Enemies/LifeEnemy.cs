using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LifeEnemy : MonoBehaviour
{
    [SerializeField] int _life;
    [SerializeField] Collider2D _colliderBlast;

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
            Destroy(gameObject);
        }
        else if (life <= 0)
        {
            Destroy(gameObject);
        }

    }
}
