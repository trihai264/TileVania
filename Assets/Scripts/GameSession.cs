using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int playerScore = 0;
    [SerializeField] Text liveText;
    [SerializeField] Text scoreText;
    // Start is called before the first frame update
    void Awake()
    {
        int numGameSession = FindObjectsOfType<GameSession>().Length;
        if(numGameSession >1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        liveText.text = playerLives.ToString();
        scoreText.text = playerScore.ToString();

    }

    public void ProcessPlayerDeath()
    {
        if(playerLives >1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    public void AddScore(int PointToAdd)
    {
        playerScore += PointToAdd;
        scoreText.text = playerScore.ToString();

    }

    void TakeLife()
    {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        liveText.text = playerLives.ToString();
    }

    void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetGamePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
