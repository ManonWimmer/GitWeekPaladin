using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivcationBlast : MonoBehaviour
{
    [SerializeField] private GameObject blast;

    private void Update()
    {
        if (LifeEnemy.Instance.blast == true)
        {
            blast.SetActive(true);
        }
    }
}
