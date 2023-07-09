    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private GameObject[] hearts;
    [SerializeField] private AudioSource sfx;
    [SerializeField] private AudioSource track01;
    [SerializeField] private GameObject startingTransition;
    int i = 0;
    void Update()
    {
        if(health <= 0)
        {
            Die();      
        }
    }
    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }  

        this.health -= amount;
        Destroy(hearts[i].gameObject);

        i++;
    }
    private void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(6);
    }
    
}   