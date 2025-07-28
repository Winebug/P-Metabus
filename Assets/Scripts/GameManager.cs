using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;

    public static GameManager Instance
    {
        get { return gameManager; }
    }

    private int currentScore = 0;

    UIManager uIManager;
    public UIManager UIManager
    { 
        get 
        { 
            return uIManager; 
        } 
    }

    private void Awake()
    {
        gameManager = this;
        uIManager = FindObjectOfType<UIManager>();
        miniGameEndHandler = FindAnyObjectByType<MiniGameEndHandler>();
    }

    public MiniGameEndHandler miniGameEndHandler;

    public void GameOver()
    {

        Debug.Log("Game Over");
        UIManager.SetRestart();
        ScoreManager scoreManager = new ScoreManager();
        scoreManager.EndGame();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;

        Debug.Log("Score: " + currentScore);
        UIManager.UpdateScore(currentScore);
    }

}