using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private GameObject player;
    [SerializeField] private float respawnTime;
    [SerializeField] private AudioSource deathSound;

    private bool isRespawning;
    private float timeOfDeath;


    public void Update()
    {
        CheckDeadPlayer();
        CheckRespawn();
    }

    private void CheckDeadPlayer()
    {
        if (!player.activeInHierarchy & !isRespawning) 
        {
            deathSound.Play();
            timeOfDeath = Time.time;
            isRespawning = true;
        }
    }

    private void CheckRespawn()
    {
        if (isRespawning & Time.time >= timeOfDeath + respawnTime) {
            player.transform.position = respawnPoint.position;
            player.SetActive(true);
            isRespawning = false;
        }
    }

}
