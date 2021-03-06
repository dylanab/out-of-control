﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : PersistentSingleton<AudioManager>
{
    public AudioSource source;
    public AudioSource bgm;

    public AudioClip shuffle;
    public AudioClip draw;

    private bool shuffling = false;

    // Quips
    public List<AudioClip> quips = new List<AudioClip>();
    private int lastQuip = -1;

    public void PlaySound(AudioClip sound) {
        source.PlayOneShot(sound);
    }

    public void PlayRandomQuip() {
        int selection = lastQuip;
        while (selection == lastQuip) {
            selection = Random.Range(0, quips.Count);
        }

        source.PlayOneShot(quips[selection]);
        lastQuip = selection;
    }

    public void Draw() {
        if (!this.shuffling)
            source.PlayOneShot(draw);
    }

    public void Shuffle() {
        if (!shuffling) 
        {
            StartCoroutine(ShuffleTimer());
            this.shuffling = true;
            source.PlayOneShot(shuffle);
        }
    }

    private IEnumerator ShuffleTimer()
    {
        yield return new WaitForSeconds(1);
        this.shuffling = false;
    }
}
