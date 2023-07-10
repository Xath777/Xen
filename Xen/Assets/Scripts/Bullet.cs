using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject target;
    public float speed;
    private Rigidbody2D rb;
    [SerializeField] private AudioSource atkHit;
    public bool turrentDOWN = false;
    public bool turrentLEFT = false;
    public bool BossBullet = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        if(turrentDOWN)
        {
            rb.velocity = new Vector2(0, -1);
        }
        else if(turrentLEFT)
        {
            rb.velocity = new Vector2(-1, 0);
        }
        else
        {
            Vector2 direction = (target.transform.position - transform.position).normalized * speed;
            rb.velocity = new Vector2(direction.x, direction.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth health_player = other.GetComponent<PlayerHealth>();
        Health health = other.GetComponent<Health>();
        EnemyMovement movement = other.GetComponent<EnemyMovement>();
        if (other.GetComponent<Health>() != null)
        {
            atkHit.Play();
            health.Damage(1);
            movement.SetHit(true);
        } 
        if (other.GetComponent<PlayerHealth>() != null)
        {
            atkHit.Play();
            health_player.Damage(1);
            movement.SetHit(true);
        }
        if(!BossBullet)
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Destroy(gameObject);
    }
}
