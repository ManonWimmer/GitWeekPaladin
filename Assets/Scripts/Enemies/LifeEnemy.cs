using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LifeEnemy : MonoBehaviour
{

    [SerializeField] int _life;
    bool inTrigger=false;
    public bool blast=false;
    [SerializeField] AttackTrigger _attackTrigger;
    [SerializeField] float _enemyScore;
    
    
    public int Life { get => _life; private set => _life = value; }

    public void EnemyTakeDamage()
    {
        Life -=1 ;
        EnemyDie(Life, true);
    }
    public void EnemyTakeBlast()
    {
        Debug.Log("take blast");
        Life -= 3;
        EnemyDie(Life, false);
    }
    void EnemyDie(int life, bool allowBlast)
    {
        Debug.Log("enemy die");
        if(life <= 0 && gameObject.CompareTag("EnemyBlast") && allowBlast)
        {
            Debug.Log("la");
            blast = true;
        }
        else if (life <= 0)
        {
            Debug.Log("ici");
            StartCoroutine(_attackTrigger.DeadDelay());
            //Destroy(gameObject);
        }

        ScoreManager.Instance.OnEnemyKilled(_enemyScore);
    }
}
