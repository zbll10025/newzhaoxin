using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOneShoot : MonoBehaviour
{
    public void ButtonPlayOneShoot(AudioClip clip)
    {
        GameObject.FindObjectOfType<MenuAudio>().PlayOneShoot(clip);
    }
}
