using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameObject sfx;
    public AudioClip[] audioClips;

    public void PlaySound(int soundNum)
    {
        GameObject s = Instantiate(sfx, Vector2.zero, Quaternion.identity);
        AudioSource a = s.GetComponent<AudioSource>();

        a.clip = audioClips[soundNum];
        a.Play();
        Destroy(s, audioClips[soundNum].length);
    }
}
