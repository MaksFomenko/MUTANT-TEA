using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundChrest : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;

    public void PlaySound()
    {
        source = GetComponent<AudioSource>();
        source.PlayOneShot(clip);
    }
}
