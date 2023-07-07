using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject BulletPrefab;
 
    void OnShoot()
    {
        Instantiate(BulletPrefab, shootingPoint.position, transform.rotation);
    }

}
