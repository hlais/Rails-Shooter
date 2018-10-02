using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShipController : MonoBehaviour {

    [Tooltip("In ms^-1")] [SerializeField] float speed = 4;
    [SerializeField] float xRange = 4.39f;
    [SerializeField] float yRange = 3;

    [SerializeField] float pitchFactor = -6.5f;
    [SerializeField]float controlPitchFactor = -15f;

    [SerializeField] float pitchYawFactor = 10.30f;
    [SerializeField] float rollThrow = -15f;

    //inputs
    float verticalThrow, horizontalThrow;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        HorizontalMovment();
        VerticleMovment();
        ProcessRotation();
        
	}

    private void ProcessRotation()
    {
        //trans.localP.y * picF/ is the rotation in relation to the location position/ when input is pressed extra 
        float pitch = transform.localPosition.y * pitchFactor + verticalThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * pitchYawFactor;
        float roll = horizontalThrow * rollThrow;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void HorizontalMovment()
    {
        horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xframe = horizontalThrow * speed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xframe;
        float restrictedRange = Mathf.Clamp(rawXPos, -xRange, xRange);

        transform.localPosition = new Vector3(restrictedRange, transform.localPosition.y, transform.localPosition.z);
    }
    private void VerticleMovment()
    {
       verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");
       
        float yFrame = verticalThrow * speed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yFrame;

        float clampedYAixis = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(transform.localPosition.x, clampedYAixis, transform.localPosition.z);
    }
    
}
