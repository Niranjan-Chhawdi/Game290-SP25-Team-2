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
    public AudioClip Pause;

    public AudioClip UnPause;

    public AudioClip OXrefill;

    public AudioClip hideGrass;

    public AudioClip buttonClicked;

    public AudioClip keyCollect;

    public AudioClip Damage;

    public AudioClip friendRevive;

    public void PlayReviveSound(){
        SFXSource.Stop();
        SFXSource.PlayOneShot(friendRevive);
    }

    public void PlayDamageSound(){
        SFXSource.volume = 0.1f;
        SFXSource.PlayOneShot(Damage);
    }

    public void PlaykeyCollectSound()
    {
        SFXSource.Stop();
        SFXSource.PlayOneShot(keyCollect);
    }

    public void PlaybuttonClickedSound()
    {
        SFXSource.Stop();
        SFXSource.PlayOneShot(buttonClicked);
    }


    public void PlayhideGrassSound()
    {
        SFXSource.Stop();
        SFXSource.PlayOneShot(hideGrass);
    }

    public void PlayOXrefillSound()
    {
        SFXSource.Stop();
        SFXSource.PlayOneShot(OXrefill);
    }


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

    public void PlayPauseSound()
    {
        SFXSource.Stop();
        SFXSource.PlayOneShot(Pause);
    }

    
    public void PlayUnPauseSound()
    {
        SFXSource.Stop();
        SFXSource.PlayOneShot(UnPause);
    }
    private void Start()
    {
        musicSource.volume = 0.1f;
        musicSource.clip = background;
        musicSource.Play();
    }
}
