using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----------- Audio Source ----------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----------- Audio Clip ----------------")]

    public AudioClip background;
    public AudioClip Hover;
    public AudioClip Click;
    public AudioClip NoClick;

    public void PlayHoverSound()
    {
        SFXSource.Stop();
        SFXSource.PlayOneShot(Hover);
    }

    public void PlayClickSound()
    {
        SFXSource.Stop();
        SFXSource.PlayOneShot(Click);
    }

    public void PlayNoClickSound()
    {
        SFXSource.Stop();
        SFXSource.PlayOneShot(NoClick);
    }

    private void Start()
    {
        musicSource.volume = 0.2f;
        musicSource.clip = background;
        musicSource.Play();
    }
}
