using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    public static SceneScript S;
    public string LevelName;
    public string NextScene;
    
    private void Awake()
    {
        S = this;
    }

    public void GoToNextScene()
    {
        SceneManager.LoadScene(NextScene);
    }
}
