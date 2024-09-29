using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameEndedText;
    public Button restartButton;
    public Button exitButton;
    public GameObject titleScreen;
    private int score;
    private float spawnRate = 1.0f;
    public bool isGameActive;
    public bool isGameEnded;
    private float gameDuration = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            UpdateTimer();
        }

    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive) 
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void UpdateTimer()
    {
        if (gameDuration > 0)
        {
            gameDuration -= Time.deltaTime; // Уменьшаем время
            timerText.text = "Time: " + Mathf.Round(gameDuration); // Обновляем текст таймера
        }
        else
        {
            GameEnded(); // Когда таймер достигает 0, игра заканчивается
        }
    }

    public void GameEnded()
    {
        gameEndedText.text = "Game Ended! Your score: " + score;
        restartButton.gameObject.SetActive(true);
        gameEndedText.gameObject.SetActive(true);
        isGameActive = false;
        isGameEnded = true;
    }

    public void GameOver()
    {
        if(!isGameEnded)
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            isGameActive = false;
        }
       
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        exitButton.gameObject.SetActive(false);
        titleScreen.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting..."); // Это сообщение появится только в редакторе
    }
}
