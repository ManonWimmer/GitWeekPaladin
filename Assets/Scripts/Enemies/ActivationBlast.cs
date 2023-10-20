using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationBlast : MonoBehaviour
{
    [SerializeField] private GameObject blast;
    [SerializeField] LifeEnemy _l;
    [SerializeField] AttackTrigger _trigger;

    private void Update()
    {
        if (_l.blast)
        {
            _trigger.isMoving = false;
            blast.SetActive(true);
            
        }
    }

}
