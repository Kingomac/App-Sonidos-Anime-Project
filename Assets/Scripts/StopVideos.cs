using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StopVideos : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void StopAll()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("VideoButton");
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].GetComponent<VideoPlayer>().Stop();
        }
    }
    public void PauseAll()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("VideoButton");
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].GetComponent<VideoPlayer>().Pause();
        }
    }
}
