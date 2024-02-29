using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    private int score;
    public TextMeshProUGUI scoreText;
    public List<GameObject> targets;
    public Button restartButton;
    private float spawnRate = 1.0f;
    private bool isGameActive = true;
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
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
    public void RestartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
