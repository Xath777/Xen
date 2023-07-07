using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField] private float bounce = 0.5f;
    [SerializeField] private Rigidbody2D rd;
    [SerializeField] private AudioSource sfx1;
    [SerializeField] private AudioSource sfx2;
    void OnTriggerEnter2D(Collider2D other)
    {
        Health health = other.GetComponent<Health>();         
        if(other.gameObject.tag == "HurtBox")
        {
            health.Damage(1); 
            rd.velocity = new Vector2(rd.velocity.x, bounce);
            sfx1.Play(); 
        }
        
    }
}
