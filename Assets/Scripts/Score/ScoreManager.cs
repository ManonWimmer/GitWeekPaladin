using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] float _scoreMultiplier = 1.05f;
    private float _currentScore = 0f;
    private bool _gameEnded = false;

    public void OnEnemyKilled(float enemyScore)
    {
        _currentScore += enemyScore;
        _currentScore *= _scoreMultiplier;
        Debug.Log($"Current Score : {_currentScore}");
    }

}
