using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    public AudioSource audioSource;
    public static SoundController soundController;
    private void Awake()
    {
        soundController = this;
    }
    public static void PlayMusic(bool _play)
    {
        if (_play)
        {
            soundController.audioSource.Play();
        }
        else
        {
            soundController.audioSource.Stop();

        }
    }
}
