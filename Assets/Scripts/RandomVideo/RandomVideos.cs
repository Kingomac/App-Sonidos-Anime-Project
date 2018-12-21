using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;

public class RandomVideos : MonoBehaviour {

    public Slider progressBar;
    public string linkslist;
    private VideoPlayer video;
    private int videonum = 99;
    public string[] videoslink = { "https://raw.githubusercontent.com/Kingomac/AppSonidosAnime/master/video/RandomVideos/kuroko.mp4" };
	// Use this for initialization
	void Start () {
        progressBar = FindObjectOfType<Slider>();
		video = GetComponent<VideoPlayer>();
        StartCoroutine(GetLink());
	}
    public IEnumerator GetLink()
    {
        UnityWebRequest www = UnityWebRequest.Get(linkslist);
        progressBar.value = www.downloadProgress;
        yield return www.SendWebRequest();
        if (!www.isNetworkError)
        { 
            Debug.Log(www.downloadHandler.text);
            videoslink = www.downloadHandler.text.Split('\n');
            videoslink[videoslink.Length - 1] = videoslink[0];
            GetVideo();
        }
    }
    public void GetVideo()
    {
        videonum = Random.Range(0, videoslink.Length-1);
        Debug.Log(videoslink.Length);
        video.url = videoslink[videonum];
        video.Prepare();
        video.Play();
    }
    void Update()
    {
        if(progressBar != null)
        {
            if (!video.isPrepared)
            {
                
                progressBar.value += 0.005f;
            }
            else Destroy(progressBar.gameObject);
        }
    }
}
