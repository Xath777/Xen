using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] int scene = 1;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] private GameObject startingTransition;
    [SerializeField] private GameObject endingTransition;
    void Start()
    {  
        StartCoroutine(Close());
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        //Score.instance.ResetScore();
    } 
    public void Reset()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
        //Score.instance.ResetScore();
    }   
    IEnumerator Close()
    {
        endingTransition.SetActive(true);
        yield return new WaitForSeconds(1f);
        endingTransition.SetActive(false);
    }

}    
