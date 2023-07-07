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

    void Update()
    {
        if(isHit)
        {  
            StartCoroutine(Poise());
        }

        else
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;

            if(distance < distanceBtwn)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            } 
        }
        
        Flip();
    }

    private void Flip()
    {
        if (rb.position.x > 0f && isPosRight)
        {
            isPosRight = !isPosRight;
            Vector2 localScale = transform.localScale;
            localScale.x = localScale.x * -1f;
            transform.localScale = localScale;
        }
    }

    public void SetHit(bool tf)
    {
        isHit = tf;
    }

    public IEnumerator Poise()
    {
        rb.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(0.1f);
        isPoising = false;
        isHit = false;      
    }
}
