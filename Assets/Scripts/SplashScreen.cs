using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SplashScreen : MonoBehaviour {

   
   

    void Start () {
        Invoke("LoadNextScreen", 3);
    }
	
    void LoadNextScreen()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);

        
    }
    
}
