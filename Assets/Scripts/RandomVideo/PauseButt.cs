using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PauseButt : MonoBehaviour {

    public VideoPlayer video;
    public GameObject quitButton;
	// Use this for initialization
	void Start () {
        video = FindObjectOfType<VideoPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
	}
    public void Pause()
    {
        if (video.isPlaying)
        {
            video.Pause();
            quitButton.SetActive(true);
        }
        else
        {
            quitButton.SetActive(false);
            video.time -= 0.2;
            video.Play();
        }
    }
}
