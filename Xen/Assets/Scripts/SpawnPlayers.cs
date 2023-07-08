using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefeb;

    public void Start()
    {
        Vector2 randomPosition = new Vector2(-6.41f, 12.22f);
        Instantiate(playerPrefeb, randomPosition, Quaternion.identity);
    }
}

