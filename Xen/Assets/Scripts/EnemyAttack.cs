using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private GameObject attackArea = default;
    private bool attacking = false;
    private float timeToAttack = 3.25f;
    private float timer = 0f;
    [SerializeField] private Rigidbody2D rb;
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }
    void Update()
    {        
        if(rb.position.x > -1.9f && rb.position.x < 1.9f)
        {
            rb.velocity = new Vector2(0, 0);
            StartCoroutine(Wait());
        }
        if(attacking)
        {
            timer += Time.deltaTime;

            if(timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
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