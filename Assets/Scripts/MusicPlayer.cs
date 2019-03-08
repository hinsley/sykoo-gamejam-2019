using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip musicClip;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AudioSource audioSource = Utils.GetAudioSource();
        if (audioSource.isPlaying)
        {
            audioSource.PlayOneShot(musicClip);
        }
    }
}
