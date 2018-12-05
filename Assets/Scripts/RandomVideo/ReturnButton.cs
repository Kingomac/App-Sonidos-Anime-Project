using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ReturnButton : MonoBehaviour {

    protected VideoPlayer video;
	// Use this for initialization
	void Start () {
        video = FindObjectOfType<VideoPlayer>();
	}
	
    private void LateUpdate()
    {
        if (!video.isPlaying) gameObject.SetActive(true);
        else gameObject.SetActive(false);
    }
}
