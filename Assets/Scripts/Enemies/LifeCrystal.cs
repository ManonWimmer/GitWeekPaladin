using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCrystal : MonoBehaviour
{
    public static LifeCrystal Instance;
    [SerializeField] int _lifeCrystal;
    [SerializeField] Slider slider;
    [SerializeField] LoadingScene _loadingDefeatScene;

    public int lifeCrystal { get => _lifeCrystal; private set => _lifeCrystal = value; }

    private void Awake()
    {
        Instance = this;
    }

    public void TakeDamage(int damage)
    {

        lifeCrystal-=damage;

        // Check Defeat :
        if (lifeCrystal <= 0)
        {
            _loadingDefeatScene.LoadScene();
        }
    }
    private void Update()
    {
        slider.value = lifeCrystal;
    }
}
