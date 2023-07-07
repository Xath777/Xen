using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static GameOver instance;
    [SerializeField] GameObject gameOver; 
    private void Awake()
    {
        instance = this;
    }
    public void GameOverMenu()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0f; 
    }
}
