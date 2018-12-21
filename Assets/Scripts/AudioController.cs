using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public AudioSource[] audios;
    public int _soundnum;
	// Use this for initialization
	void Start () {
        audios = GetComponents<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    /// <summary>
    /// Reproducir uno de los AudioSource aleatorios
    /// </summary>
    public void Play()
    {
        try { FindObjectOfType<AudioController>().StopAll(); } catch { }
        try { FindObjectOfType<StopVideos>().PauseAll(); } catch { }
        bool isPlaying = false;
        for(int i = 0; i < audios.Length; i++)
        {
            if (audios[i].isPlaying)
            {
                isPlaying = true;
                break;
            }
        }
        _soundnum = Random.Range(0, audios.Length);
        if (!isPlaying) audios[_soundnum].Play();
        Debug.Log(_soundnum);
    }
    /// <summary>
    /// Detiene todos los audios que estén sonando, NO funciona con vídeos.
    /// </summary>
    public void StopAll()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("SoundButton");
        AudioSource[] sr;
        for (int i = 0; i < objects.Length; i++)
        {
            sr = objects[i].GetComponents<AudioSource>();
            for (int z = 0; z < sr.Length; z++)
            {
                if (sr[z].isPlaying)
                {
                    sr[z].Stop();
                    break;
                }
            }
        }
    }
}
