using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // ----- FIELDS ----- //
    [SerializeField] float _scoreMultiplier = 1.05f;
    [SerializeField] TMP_Text _scoreText; 
    private float _currentScore = 0f;
    // ----- FIELDS ----- //

    public void OnEnemyKilled(float enemyScore)
    {
        _currentScore += enemyScore;
        _currentScore *= _scoreMultiplier;
        Debug.Log($"Current Score : {_currentScore}");
        UpdateUIScore();
    }

    private void UpdateUIScore()
    {
        _currentScore = (int)_currentScore;
        _scoreText.text = $"Score : {_currentScore.ToString()}";
    }

    // Save final score : 
    void OnDisable()
    {
        PlayerPrefs.SetInt("score", (int)_currentScore);
    }

    // A mettre dans pour récup le score dans le end menu :
    /*
    void OnEnable() 
    {
        _currentScore = PlayerPrefs.GetInt("score");
    }
    */

    // Rajouter dans le script enemy :
    // [SerializeField] float _enemyScore;
    // [SerializeField ScoreManager _scoreManager;
    // Quand enemi die, avant de destroy : 
    // _scoreManager.OnEnemyKilled(_enemyScore);

    // A ajouter dans le script lifeCrystal : 
    // [SerializeField] LoadingScene _loadingScene; -> A mettre dans le gameObject avec comme valeur EndScene (rajouter le score ?)
    //public void TakeDamage(int damage)
    //{

    //lifeCrystal -= damage;
    //if (lifeCrystal <= 0)
    //{
    //_loadingScene.LoadScene();
    //}
    //}
}
