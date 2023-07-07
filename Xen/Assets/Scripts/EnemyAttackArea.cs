using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyAttackArea : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        TowerHealth health = other.GetComponent<TowerHealth>();
        EnemyMovement movement = other.GetComponent<EnemyMovement>();
        if (health != null)
        {
            health.Damage(damage);
            if (movement != null)
            {
                movement.SetHit(true);
            }
        }
    }  
}
    
