using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : PersistentSingleton<AudioManager>
{
    public AudioSource source;
    public AudioSource bgm;

    // Quips
    public List<AudioClip> quips = new List<AudioClip>();
    private int lastQuip = -1;

    public void PlaySound(AudioClip sound) {
        source.PlayOneShot(sound);
    }

    public void PlayRandomQuip() {
        int selection = lastQuip;
        while (selection == lastQuip) {
            selection = Random.Range(0, quips.Count - 1);
        }

        source.PlayOneShot(quips[selection]);
        lastQuip = selection;
    }
}
