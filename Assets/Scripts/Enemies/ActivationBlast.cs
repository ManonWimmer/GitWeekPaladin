using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationBlast : MonoBehaviour
{
    [SerializeField] private GameObject blast;
    [SerializeField] LifeEnemy _l;

    private void Update()
    {
        if (_l.blast)
        {
            Debug.Log("in");
            blast.SetActive(true);
        }
    }

}
