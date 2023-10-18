using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public struct Wave
{
    public int EnemiesToSpawn;
    public float TimeBetweenEachSpawn;
}


public class EnemiesWavesSpawn : MonoBehaviour
{
    [SerializeField] Transform _spawnZone1;
    [SerializeField] Transform _spawnZone2;
    [SerializeField] Transform _spawnZone3;
    [SerializeField] Transform _spawnZone4;
    [SerializeField] Wave[] _waves;

}
