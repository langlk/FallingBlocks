using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text secondsSurvived;
    bool gameOver;

    void Start() {
        FindObjectOfType<Player>().OnPlayerDeath += OnGameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene(0);
        }
    }

    void OnGameOver() {
        gameOverScreen.SetActive(true);
        secondsSurvived.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        gameOver = true;
    }
}
