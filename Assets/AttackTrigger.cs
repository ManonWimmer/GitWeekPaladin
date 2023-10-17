using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AttackTrigger : MonoBehaviour
{
    [SerializeField] Enemy1 enemy1;
    [SerializeField] LifeCrystal lifeCrystal;
    public bool isMoving;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("contact");
        if (collision.gameObject.CompareTag("Crystal"))
        { 
            lifeCrystal.TakeDamage(1);
            isMoving = false;
        }
    }
}
