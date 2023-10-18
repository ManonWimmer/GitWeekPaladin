using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackTrigger : MonoBehaviour
{
    [SerializeField] Enemy1 enemy1;
    public bool isMoving;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("contact");
        if (collision.gameObject.CompareTag("Crystal"))
        {
            LifeCrystal.Instance.TakeDamage(1);
            isMoving = false;
        }
    }
}
