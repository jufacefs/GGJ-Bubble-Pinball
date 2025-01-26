using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    public static SceneScript S;
    public string LevelName;
    public string NextScene;

    public string StartLevel;

    public string Instructions;

    public string Credits;

    public string IntroScene;

    public string ChallengeLevel;
    
    private void Awake()
    {
        S = this;
    }

    public void GoToNextScene()
    {
        SceneManager.LoadScene(NextScene);
    }

    public void StartButton()
    {
        SceneManager.LoadScene(StartLevel);
    }

    public void InstructionsButton()
    {
        SceneManager.LoadScene(Instructions);

    }

    public void CreditsButton()
    {
        SceneManager.LoadScene(Credits);
    }

    public void BackButton()
    {
        SceneManager.LoadScene(IntroScene);
    }

    public void ChallengeButton()
    {
        SceneManager.LoadScene(ChallengeLevel);
    }
}
