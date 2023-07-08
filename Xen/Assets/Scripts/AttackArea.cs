using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField] private AudioSource atkHit;
    [SerializeField] private int damage = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        BossHealth bosshealth = other.GetComponent<BossHealth>();
        Health health = other.GetComponent<Health>();
        EnemyMovement movement = other.GetComponent<EnemyMovement>();   
        if(other.GetComponent<Health>() != null)
        {
            atkHit.Play();
            health.Damage(damage);
            movement.SetHit(true);
        }
        if (other.GetComponent<BossHealth>() != null)
        {
            atkHit.Play();
            bosshealth.Damage(damage);
            movement.SetHit(true);
        }
    }
}
    

