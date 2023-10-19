using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationBlast : MonoBehaviour
{
    [SerializeField] private GameObject blast;

    private void Update()
    {
        if (LifeEnemy.Instance.blast)
        {
            Debug.Log("in");
            blast.SetActive(true);
        }
    }

}
