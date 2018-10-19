using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] GameObject trumpAudio;
    AudioSource audioSource;
    float currentVolume;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        currentVolume = audioSource.volume;
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;

        print("Number of music players in this scene" + numMusicPlayers);

        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else

            DontDestroyOnLoad(gameObject);


    }

    public void TrumpAudio()
    {
        audioSource.volume = 0.1f;
        GameObject fx = Instantiate(trumpAudio, transform.position, transform.rotation);
        Invoke("RevertVolumeToOriginal", 10f);
    }

    private void RevertVolumeToOriginal()
    {
        audioSource.volume = currentVolume;
    }
}




    
