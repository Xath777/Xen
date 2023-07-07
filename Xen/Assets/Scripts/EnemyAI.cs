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
    [SerializeField] private GameObject player;
    private float distance;
    private GameObject attackArea = default;
    private bool attacking = false;
    private float timeToAttack = 3.25f;
    private float timer = 0f;

    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    void Update()
    {
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

        if(distance < distanceBtwn)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }  
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
        yield return new WaitForSeconds(.8f);
        Attack();
    }
}
