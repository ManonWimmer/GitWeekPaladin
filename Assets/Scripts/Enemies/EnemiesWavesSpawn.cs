using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using Random = UnityEngine.Random;

[Serializable]
public struct Wave
{
    public int EnemiesToSpawn;
    public float TimeBetweenEachSpawn;
    public GameObject[] EnemiesPrefabs;
}

public class EnemiesWavesSpawn : MonoBehaviour
{
    // ----- FIELDS ----- //
    [SerializeField] Transform[] _spawnZones;
    [SerializeField] Wave[] _waves;
    // ----- FIELDS ----- //

    private void Start()
    {
        StartCoroutine(ManageWaves());
    }

    IEnumerator ManageWaves()
    {
        for (int _currentWave = 0; _currentWave < _waves.Length; _currentWave++)
        {
            Debug.Log($"Current wave : {_currentWave}");
            yield return StartCoroutine(StartWave(_currentWave));
        }
        yield return null;
        //  Toutes les vagues sont finies = Victory ? -> Victory screen, non c'est pas fini les ennemis ont juste appar -> Score manager
    }

    IEnumerator StartWave(int waveNumber)
    {
        // Wave parameters :
        int enemiesToSpawn = _waves[waveNumber].EnemiesToSpawn;
        float timeBetweenEachSpawn = _waves[waveNumber].TimeBetweenEachSpawn;
        GameObject[] waveEnemiesPrefabs = _waves[waveNumber].EnemiesPrefabs;

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Debug.Log($"For start wave : {i}");

            // Random enemy :
            int randomEnemyIndex = Random.Range(0, (waveEnemiesPrefabs.Length));
            GameObject enemyRandom = waveEnemiesPrefabs[randomEnemyIndex];

            // Random spawn zone :
            int randomZoneIndex = Random.Range(0, (_spawnZones.Length));
            Transform spawnZoneRandom = _spawnZones[randomZoneIndex];

            // Spawn :
            Instantiate(enemyRandom, spawnZoneRandom.position, Quaternion.identity);

            // Wait before new spawn :
            yield return new WaitForSeconds(timeBetweenEachSpawn);
        }
        yield return null;
    }

    public int GetTotalEnemiesInGame()
    {
        int totalEnemies = 0;

        foreach (Wave wave in _waves) 
        {
            totalEnemies += wave.EnemiesToSpawn;
        }

        return totalEnemies;
    }



}




