using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private bool isPosRight = true;
    private bool isHit = false;
    private bool isPoising = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 16;

    void Update()
    {
        if(isHit)
        {  
            StartCoroutine(Poise());
        }

        else
        {
            if (rb.position.x < 0f)
            {
                rb.velocity = new Vector2(speed * 0.2f, rb.velocity.y);
            }
            else if (rb.position.x > 0f)
            {
                rb.velocity = new Vector2(-speed * 0.2f, rb.velocity.y);
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
