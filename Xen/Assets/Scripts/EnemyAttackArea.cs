using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyAttackArea : MonoBehaviour
{
    [SerializeField] private AudioSource atkHit;
    [SerializeField] private int damage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth health = other.GetComponent<PlayerHealth>();
        EnemyAI movement = other.GetComponent<EnemyAI>();
        if (health != null)
        {
            atkHit.Play();
            health.Damage(damage);
            if (movement != null)
            {
                movement.SetHit(true);
            }
        }
    }  
}
    
