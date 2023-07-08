using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    [SerializeField] private int health = 10;
    public bool player_inv = false;
    public int scene = 2;
    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        this.health -= amount;

        if(health <= 0)
        {
           Die(); 
        }
    }
    
    private void Die()
    {               
        Destroy(gameObject);
        if(player_inv)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(scene);

        }
    }
}   