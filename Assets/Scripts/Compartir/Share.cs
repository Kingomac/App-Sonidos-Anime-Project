﻿using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using NatShareU;
using UnityEngine.UI;
using UnityEngine.Video;

public class Share : MonoBehaviour
{
    public ShareController shareController;
    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        shareController = GetComponentInParent<ShareController>();
        if (!Directory.Exists(Application.temporaryCachePath + "/Share/")) Directory.CreateDirectory(Application.temporaryCachePath + "/Share/");
        StartCoroutine(GetLinks());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator GetLinks()
    {
        UnityWebRequest www = UnityWebRequest.Get(shareController.audioController.listLink);
        yield return www.SendWebRequest();
        if (!www.isNetworkError)
        {
            shareController.SetLinks(www.downloadHandler.text.Split('\n'));
        }
        else
        {
            Debug.Log("Network error");
        }
    }

    public IEnumerator ShareSong(int num)
    {
        StartCoroutine(GetLinks());
        UnityWebRequest www = UnityWebRequest.Get(shareController.GetLink(num));
        yield return www.SendWebRequest();
        File.WriteAllBytes(Application.temporaryCachePath + "/Share/sound.mp3",www.downloadHandler.data);
        NatShare.ShareMedia(Application.temporaryCachePath + "/Share/sound.mp3");
    }
    public void CallShareSong(int num)
    {
        StartCoroutine(ShareSong(num));
    }
}
