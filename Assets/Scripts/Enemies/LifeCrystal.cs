using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCrystal : MonoBehaviour
{
    public static LifeCrystal Instance;
    [SerializeField] int _lifeCrystal;
    [SerializeField] Slider slider;

    public int lifeCrystal { get => _lifeCrystal; private set => _lifeCrystal = value; }

    private void Awake()
    {
        Instance = this;
    }

    public void TakeDamage(int damage)
    {

        lifeCrystal-=damage;
    }
    private void Update()
    {
        slider.value = lifeCrystal;
    }
}
