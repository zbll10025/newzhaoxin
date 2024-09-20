using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zhou.Tool.Singleton;
public class MenuAudio : Singleton<MenuAudio>
{
    private AudioSource audioSource;
    private void Start()
    {
       audioSource = GetComponent<AudioSource>();
    }
    public void PlayOneShoot(AudioClip audioClip)
    {
       
        audioSource.PlayOneShot(audioClip);
    }
}
