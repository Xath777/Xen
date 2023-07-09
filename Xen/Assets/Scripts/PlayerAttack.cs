using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;
    private bool attacking = false;
    private float timeToAttack = 0.2f;
    private float timer = 0f;
    [SerializeField] Animator anim;
    [SerializeField] private GameObject atk;
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if(attacking)
        {
            atk.SetActive(true);
            timer += Time.deltaTime;

            if(timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
                atk.SetActive(false);
            }
        }
    }

    public void OnAttack()
    {      
        Attack();
    }

    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }
}