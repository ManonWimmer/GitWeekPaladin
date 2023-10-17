using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCrystal : MonoBehaviour
{
    [SerializeField] int _lifeCrystal;

    public int lifeCrystal { get => _lifeCrystal; private set => _lifeCrystal = value; }

    public void TakeDamage(int damage)
    {

        lifeCrystal-=damage;
    }
}
