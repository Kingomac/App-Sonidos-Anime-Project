using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    public AudioClip[] audios;
    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
    }
    /// <summary>
    /// Reproducir uno de los AudioSource aleatorios
    /// </summary>
    public void Play()
    {
        FindAndStopAll();
        audioSource.clip = audios[Random.Range(0, audios.Length)];
        audioSource.Play();
    }
    public void FindAndStopAll()
    {
        var audios  = FindObjectsOfType<AudioSource>();
        foreach(AudioSource audio in audios)
        {
            audio.Stop();
        }
    }
    /// <summary>
    /// Con el número de AudioSource reprodúcelo
    /// </summary>
    /// <param name="audioNum"></param>
    public void SelectAndPlay(int audioNum)
    {
        FindAndStopAll();
        audioSource.clip = audios[audioNum];
        audioSource.Play();
    }
}
