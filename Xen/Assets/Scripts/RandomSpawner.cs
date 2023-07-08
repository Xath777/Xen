using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    private float startTimeBtwSpawns = 1.5f;
    private float timeBtwSpawns1;
    private float timeBtwSpawns2;
    private float timeBtwSpawns3;
    private float timeBtwSpawns4;

    public float multiplier = 1f;
    [SerializeField] private bool pc_solo = false;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject[] enemyPrefabs;
    void Start()
    {
        timeBtwSpawns1 = startTimeBtwSpawns;
    }   
    void Update()
    {
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);
        
        if (PlayerPrefs.GetInt("score", 0) >= 0 && timeBtwSpawns1 <= 0)
        {
            Instantiate(enemyPrefabs[0], spawnPoints[randSpawnPoint].position, Quaternion.identity);
            timeBtwSpawns1 = 3.5f * multiplier;
        }
        else
        {
            timeBtwSpawns1 -= Time.deltaTime;
        }
    }
}
