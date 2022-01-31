using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioManager : MonoBehaviour
{
    private static MenuAudioManager audioManager;
    public static MenuAudioManager Instance
    {
        get
        {
            if (audioManager == null)
            {
                audioManager = GameObject.FindObjectOfType<MenuAudioManager>();

                if (audioManager == null)
                {
                    audioManager = new GameObject().AddComponent<MenuAudioManager>();
                }
            }

            return audioManager;
        }
    }

    public AudioSource loopMelodieSource;
    public AudioSource clickingAudioSource;



    private void Start()
    {
        loopMelodieSource.Play();
    }

    public void PlayClickSound()
    {
        clickingAudioSource.Play();
    }

    public void StopLoopAudio()
    {
        loopMelodieSource.Stop();
    }
}
