using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LifeEnemy : MonoBehaviour
{
    public static LifeEnemy Instance { get; private set; }
    [SerializeField] int _life;
    bool inTrigger=false;
    public bool blast=false;
    private void Awake()
    {
        Instance = this; 
    }
    
    public int Life { get => _life; private set => _life = value; }

    public void EnemyTakeDamage()
    {
        Life -=1 ;
        EnemyDie(Life);
    }
    public void EnemyTakeBlast()
    {
        Life -= 3;
        EnemyDie(Life);
    }
    void EnemyDie(int life)
    {
        if(life <= 0 && gameObject.CompareTag("EnemyBlast"))
        {
            blast = true;
        }
        else if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
