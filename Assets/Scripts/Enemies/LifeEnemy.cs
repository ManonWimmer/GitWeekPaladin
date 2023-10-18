using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LifeEnemy : MonoBehaviour
{
    [SerializeField] int life;

    public int Life { get => life; private set => life = value; }

    public void EnemyTakeDamage()
    {
        Life -=1 ;
        EnemyDie(Life);
    }

    void EnemyDie(int life)
    {
        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
