using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCrystal : MonoBehaviour
{
    public static LifeCrystal Instance;
    [SerializeField] int _lifeCrystal;

    public int lifeCrystal { get => _lifeCrystal; private set => _lifeCrystal = value; }

    private void Awake()
    {
        Instance = this;
    }

    public void TakeDamage(int damage)
    {

        lifeCrystal-=damage;
    }
}
