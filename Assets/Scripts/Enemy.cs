using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(BoxCollider))]
public class Enemy : MonoBehaviour {

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
	// Use this for initialization
	void Start () {

        AddNonTriggerBox();
		
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
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
