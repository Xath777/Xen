using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private bool isPosRight = true;
    private bool isHit = false;
    private bool isPoising = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 16f;
    [SerializeField] private float distanceBtwn = 10f;
    private GameObject player;
    private float distance;
    private GameObject attackArea = default;
    private bool attacking = false;
    private float timeToAttack = 3.25f;
    private float timer = 0f;
    private float nextFireTime;
    public float shootingRange;
    public float fireRate = 1f;
    public GameObject bullet;
    public GameObject bulletParent;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        attackArea = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (isHit)
        {
            StartCoroutine(Poise());
        }

        if (distance < 2)
        {
            StartCoroutine(Wait());
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);

            }
        }
     
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        if(distance < distanceBtwn && distance > 1)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }  
        if(distance <= shootingRange && nextFireTime < Time.time)
        {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
    }

    public IEnumerator Poise()
    {
        rb.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(0.1f);
        isPoising = false;
        isHit = false;
    }

    public void SetHit(bool tf)
    {
        isHit = tf;
    }

    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(.5f);
        Attack();
    }
}
