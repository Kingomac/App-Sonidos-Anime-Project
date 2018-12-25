using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Networking;

public class ShareController : MonoBehaviour
{
    public AudioController audioController;
    public string[] Links;

    public void SetLinks(string[] a)
    {
        Links = a;
    }
    public string[] GetLinks()
    {
        return Links;
    }
    public string GetLink(int n)
    {
        return Links[n];
    }
}
