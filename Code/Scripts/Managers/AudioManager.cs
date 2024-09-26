using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangePlayersAudio(AudioClip audio, bool loop){
        audioSource.Stop();
        audioSource.clip = audio;
        audioSource.Play();
        audioSource.loop = loop;
    }

    public void StopPlayerAudio(){
        if (audioSource.isPlaying){
            audioSource.Stop();
        }
    }
}
