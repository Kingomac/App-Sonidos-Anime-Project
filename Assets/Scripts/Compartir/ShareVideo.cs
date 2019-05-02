using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using NatShareU;

public class ShareVideo : MonoBehaviour
{
    public void Share(VideoPlayer video)
    {
        NatShare.ShareMedia(video.clip.originalPath);
    }
}
