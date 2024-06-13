using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    public AudioClip background;

    private void Start()
    {
        if(gameObject != null)
        {
            musicSource.clip = background;
            musicSource.Play();
        }
        else
        {
            musicSource.Pause();
        }


    }
}
