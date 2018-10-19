using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(BoxCollider))]
public class Enemy : MonoBehaviour {

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    // Use this for initialization
    [SerializeField] int hitPoints = 12;
     [SerializeField] int health = 15;

    ScoreBoard scoreBoard;
	void Start () {

        AddNonTriggerBox();
        scoreBoard = FindObjectOfType<ScoreBoard>();
		
	}

    private void AddNonTriggerBox()
    {
      
       Collider shipCollider =   gameObject.AddComponent<BoxCollider>();
        shipCollider.isTrigger = false;
        
    }

   
 
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if (health <= 0)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        scoreBoard.HitPoints(hitPoints);
        health--;
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, transform.rotation);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
