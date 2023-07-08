    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private GameObject[] hearts;
    [SerializeField] public Animator Anim;
    [SerializeField] public Animator Anim_T;
    [SerializeField] private AudioSource sfx;

    RandomSpawner rs;
    int i = 0;
    void Update()
    {
        if(health <= 0)
        {
            Die();                  
        }
        if (health < 4)
        {
            rs.multiplier = 0.7777f;
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
        //Anim.Play("Shake_1");
        //Anim_T.Play("Hit");
        //sfx.Play();
        i++;
    }
    private void Die()
    {  
        Destroy(gameObject);
        Time.timeScale = 1f;

        //LAST SCENE ER JONNO
        SceneManager.LoadScene(6);
        
    }
}   