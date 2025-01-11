using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundUniversal : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip Punch1, Punch3,Kick2, Whoosh, KnockDown, Ground, Dead;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Punch1_Sound()
    {
        audioSource.volume = .5f;
        audioSource.clip = Punch1;
        audioSource.Play();
    }

    public void Punch3_Sound()
    {
        audioSource.volume = .75f;
        audioSource.clip = Punch3;
        audioSource.Play();
    }

    public void Kick2_Sound()
    {
        audioSource.volume = .75f;
        audioSource.clip = Kick2;
        audioSource.Play();
    }

    public void KnockDown_Sound()
    {
        audioSource.volume = .5f;
        audioSource.clip = KnockDown;
        audioSource.Play();
    }

    public void Ground_Sound()
    {
        audioSource.volume = .05f;
        audioSource.clip = Ground;
        audioSource.Play();
    }

    public void Dead_Sound()
    {
        audioSource.volume = .9f;
        audioSource.clip = Dead;
        audioSource.Play();
    }
}
