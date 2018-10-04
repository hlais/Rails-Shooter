using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [SerializeField] GameObject explosion;
    [SerializeField] float levelLoadDelay = 1f;
    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
     
        SendMessage("OnPlayerDeath");
        explosion.SetActive(true);
        Invoke("ReloadLevel", levelLoadDelay);

        
            
    }
    void ReloadLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentLevel);
        
        
    }
}
