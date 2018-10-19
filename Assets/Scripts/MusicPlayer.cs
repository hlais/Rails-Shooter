using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    [SerializeField] AudioClip donaldTrump;
    private void Awake()
    {
       
       int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;

        print("Number of music players in this scene" + numMusicPlayers);

         if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
      
            DontDestroyOnLoad(gameObject);
               
        
    }
    public void PlayDonalodAudio()
    {
        AudioSource.PlayClipAtPoint(donaldTrump, transform.position);
    }
    


 
}
