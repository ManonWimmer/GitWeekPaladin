using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // ----- FIELDS ----- //
    [SerializeField] float _scoreMultiplier = 1.05f;
    //[SerializeField] TMP_Text _scoreText;
    [SerializeField] EnemiesWavesSpawn _enemiesWavesSpawn;
    [SerializeField] LoadingScene _loadingVictoryScene;
    private float _currentScore = 0f;
    private float _numberOfEnemyKilled;
    private float _totalEnemiesEndGame;

    public static ScoreManager Instance;
    // ----- FIELDS ----- //

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _totalEnemiesEndGame = _enemiesWavesSpawn.GetTotalEnemiesInGame();
        Debug.Log(_totalEnemiesEndGame);
    }

    public void OnEnemyKilled(float enemyScore)
    {
        _currentScore += enemyScore;
        _currentScore *= _scoreMultiplier;
        _numberOfEnemyKilled++; 
        //Debug.Log($"Current Score : {_currentScore}");
        //UpdateUIScore();
        CheckVictory();
    }

    /*
    private void UpdateUIScore()
    {
        _currentScore = (int)_currentScore;
        _scoreText.text = $"Score : {_currentScore.ToString()}";
    }
    */

    private void CheckVictory()
    {
        Debug.Log(_totalEnemiesEndGame - _numberOfEnemyKilled);
        if (_numberOfEnemyKilled == _totalEnemiesEndGame)
        {
            
            _loadingVictoryScene.LoadScene();
        }
    }

    /*
    // Save final score : 
    void OnDisable()
    {
        PlayerPrefs.SetInt("score", (int)_currentScore);
    }
    */

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



}
