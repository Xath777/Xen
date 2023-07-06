using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource track01;
    [SerializeField] GameObject mainMenu;
    [SerializeField] private GameObject startingTransition;
    [SerializeField] private GameObject endingTransition;
    public void Exit()
    {
        Application.Quit();
    }
    void Start()
    { 
        track01.Play();
        StartCoroutine(Close());

        Application.targetFrameRate = 60;
    }

    public void Game()
    {   
        StartCoroutine(Load(1));
    }

    IEnumerator Load(int n)
    {
        float timeToFade = 1f;
        float timeElapsed = 0f;
        startingTransition.SetActive(true);
        while(timeElapsed < timeToFade)
        {
            track01.volume = Mathf.Lerp(0.289f, 0, timeElapsed/timeToFade);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        track01.Stop();
        SceneManager.LoadScene(n);
    }
    IEnumerator Close()
    {
        endingTransition.SetActive(true);
        yield return new WaitForSeconds(1f);
        endingTransition.SetActive(false);
    }
}
