using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript S;
    public int StartingLives = 3;
    public int livesRemaining; 

    public GameObject BubblePrefab;

    public string IntroScene;

    private void Awake()
    {
        if (GameManagerScript.S)
        {
            Destroy(this.gameObject);

        } else
        {
            S = this;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);


        if (livesRemaining == 0)
        {
            livesRemaining = StartingLives;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GameWin()
    {
        //bubble effect
        //victory noise
        //change to next level
        SceneScript.S.GoToNextScene();
    }


    public void PlayerDeath()
    {
        livesRemaining = livesRemaining - 1;
        //once intro scene made change scene to load
        if (livesRemaining == 0)
        {
            SceneManager.LoadScene(IntroScene);
            livesRemaining = StartingLives;
        } else
        {
            StartCoroutine(ResetRound());
        }
    }



    public IEnumerator ResetRound()
    {
        yield return new WaitForSeconds(3f);

        Instantiate(BubblePrefab, new Vector3(0, -5, 0), Quaternion.identity);
    }
}
