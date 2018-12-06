using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class News : MonoBehaviour {

    public Slider progressBar;
    public Text news;
    public NewsController controller;
    public string newsURL = "https://raw.githubusercontent.com/Kingomac/AppSonidosAnime/master/news.txt";

    // Use this for initialization
    void Start () {
        progressBar = GetComponentInChildren<Slider>();
        controller = FindObjectOfType<NewsController>();
        if (!controller.newsShowed) StartCoroutine(GetNews());
        else gameObject.SetActive(false);
    }

	// Update is called once per frame
	void Update () {
		
	}
    public IEnumerator GetNews()
    {
        WWW www = new WWW(newsURL);
        while (!www.isDone)
        {
            progressBar.value = www.progress;
            yield return null;
        }
        if (string.IsNullOrEmpty(www.error))
        {
            Destroy(progressBar.gameObject);
            news.text += www.text;
            gameObject.SetActive(true);
        }
        else gameObject.SetActive(false);
    }
    public void Destroy()
    {
        controller.newsShowed = true;
        Destroy(gameObject);
    }
}
