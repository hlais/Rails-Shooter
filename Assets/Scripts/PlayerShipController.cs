using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShipController : MonoBehaviour {
    [Header ("General")]
    [Tooltip("In ms^-1")] [SerializeField] float speed = 4;
    [SerializeField] float xRange = 4.39f;
    [SerializeField] float yRange = 3;
    [SerializeField] GameObject[] guns;

    [Header ("Screen Position")]
    [SerializeField] float pitchFactor = -6.5f;
    [SerializeField] float controlPitchFactor = -15f;
    [Header("Control ")]
    [SerializeField] float pitchYawFactor = 10.30f;
    [SerializeField] float rollThrow = -15f;

    bool isControlEnabled = true;

    //inputs
    float verticalThrow, horizontalThrow;
	
	
	// Update is called once per frame
	void Update () {

        ControllerHandler();
        
	}
    private void ControllerHandler()
    {
        if (isControlEnabled)
        {
            HorizontalMovment();
            VerticleMovment();
            ProcessRotation();
            ProcessFiring();
        }
    }

    private void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            ActivateGuns();
        }
        else
        {
            DeActivateGuns();
        }
    }

    private void DeActivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }
    }

    private void ActivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(true);
        }
    }

    private void OnPlayerDeath() // called by string referene 
    {
        isControlEnabled = false;
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
