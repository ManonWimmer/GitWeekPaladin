using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    // ----- FIELDS ----- //
    [SerializeField] string _sceneName;
    // ----- FIELDS ----- //

    public void LoadScene()
    {
        SceneManager.LoadScene(_sceneName, LoadSceneMode.Single);
    }
}
