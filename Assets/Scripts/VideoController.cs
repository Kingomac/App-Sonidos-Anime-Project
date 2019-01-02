using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour {
    private VideoPlayer video;
    public GameObject cube;
    [Range(0.01f, 0.5f)]
    public float velocidad = 0.5f;
	// Use this for initialization
	void Start () {
        video = GetComponent<VideoPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (video.isPlaying)
        {
            cube.SetActive(true);
        }
        else
        {
            cube.SetActive(false);
        }
	}
    public void Play()
    {
        try
        {
            FindObjectOfType<AudioController>().StopAll();
        }
        catch
        {

        }
        try
        {
            FindObjectOfType<StopVideos>().PauseAll();
        }
        catch
        {

        }
        Material cubeM = cube.GetComponent<Renderer>().material;
        if (video.isPlaying)
        {
            video.Pause();
            StartCoroutine(FadeOut(cubeM));
        }
        else
        {  
            cubeM.color = new Color(1, 1, 1, 0);
            StartCoroutine(FadeIn(cubeM));
            video.Prepare();
            video.Play();
        }
    }
    private IEnumerator FadeIn(Material cubeM)
    {
        Color c = cubeM.color;
        while(cubeM.color.a < 1)
        {
            cubeM.color = c;
            c.a += velocidad;
            yield return null;
        }
    }
    private IEnumerator FadeOut(Material cubeM)
    {
        Color c = cubeM.color;
        while (cubeM.color.a > 0)
        {
            cubeM.color = c;
            c.a -= velocidad;
            yield return null;
        }
    }
    public void Pause()
    {
        video.Pause();
    }
    public void Stop()
    {
        video.Stop();
    }
}
