using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SplashScreen : MonoBehaviour {

   
    // Use this for initialization

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start () {
        Invoke("LoadNextScreen", 3);
    }
	
	// Update is called once per frame
	void Update () {

        
		
	}
    void LoadNextScreen()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);

        
    }
    
}
