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
}

public class EnemiesWavesSpawn : MonoBehaviour
{
    [SerializeField] Transform[] _spawnZones;
    [SerializeField] Wave[] _waves;
    [SerializeField] GameObject[] _enemiesPrefabs;
    private bool _coroutineRunning = false;

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
    }

    IEnumerator StartWave(int waveNumber)
    {
        _coroutineRunning = true;

        int enemiesToSpawn = _waves[waveNumber].EnemiesToSpawn;
        float timeBetweenEachSpawn = _waves[waveNumber].TimeBetweenEachSpawn;

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Debug.Log($"For start wave : {i}");
            // Random enemy :
            int randomEnemyIndex = Random.Range(0, (_enemiesPrefabs.Length));
            GameObject enemyRandom = _enemiesPrefabs[randomEnemyIndex];

            // Random spawn zone :
            int randomZoneIndex = Random.Range(0, (_spawnZones.Length));
            Transform spawnZoneRandom = _spawnZones[randomZoneIndex];

            // Spawn :
            Instantiate(enemyRandom, spawnZoneRandom.position, Quaternion.identity);

            // Wait before new spawn :
            yield return new WaitForSeconds(timeBetweenEachSpawn);
        }

        _coroutineRunning = false;
        yield return null;
    }

}




