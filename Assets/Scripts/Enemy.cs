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

    // Update is called once per frame
 
    private void OnParticleCollision(GameObject other)
    {
        GameObject fx = Instantiate(deathFX, transform.position, transform.rotation);
        scoreBoard.HitPoints(hitPoints);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
