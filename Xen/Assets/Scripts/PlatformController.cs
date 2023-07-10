using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Transform posA, posB;
    public float speed;
    Vector2 targetpos;

    void Start()
    {
        targetpos = posB.position;
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, posA.position) < .1f) 
        targetpos = posB.position;

        if(Vector2.Distance(transform.position, posB.position) < .1f) 
        targetpos = posA.position;

        transform.position = Vector2.MoveTowards(transform.position, targetpos, speed * Time.deltaTime);
    }
}
