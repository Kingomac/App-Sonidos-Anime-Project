using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ShareController : MonoBehaviour
{
    public AudioController audioController;
    public Button parentButton;
    public string[] Links;

    public void Start()
    {
        SetParentButton(false);
    }
    private void OnDisable()
    {
        SetParentButton(true);
    }
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
    public void SetParentButton(bool active)
    {
        parentButton = audioController.gameObject.GetComponent<Button>();
        parentButton.enabled = active;
    }
}
