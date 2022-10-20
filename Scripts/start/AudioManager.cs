using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    MusicData musicData;

    private void Awake()
    {
        musicData = FindObjectOfType<MusicData>();
        audioSource = GetComponent<AudioSource>();

        audioSource.PlayOneShot(musicData.list[musicData.id].music);
    }
}
