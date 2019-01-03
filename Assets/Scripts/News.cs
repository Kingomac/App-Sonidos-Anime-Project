using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;
using System;

public class News : MonoBehaviour {
    public Text title;
    public Slider progressBar;
    public Text news;
    public NewsController controller;
    public string newsURL = "https://raw.githubusercontent.com/Kingomac/AppSonidosAnime/master/news.txt";
    private Image[] backgrounds;
    private float[] backAlpha;
    // Use this for initialization
    void Awake () {
        backgrounds = GetComponentsInChildren<Image>();
        progressBar = GetComponentInChildren<Slider>();
        controller = FindObjectOfType<NewsController>();
        if (!controller.newsShowed) StartCoroutine(GetNews());
        else gameObject.SetActive(false);
        backAlpha = new float[backgrounds.Length];
        for(int i = 0; i < backgrounds.Length; i++)
        {
            backAlpha[i] = backgrounds[i].color.a;
        }  
    }
    private void Start()
    {
        Hide();
    }
    public void Hide()
    {
        foreach(Image back in backgrounds)
        {
            back.color = new Color(back.color.r, back.color.g, back.color.b, 0);
            back.gameObject.SetActive(false);
        }
        title.color = new Color(title.color.r, title.color.g, title.color.b, 0);
        title.gameObject.SetActive(false);
        news.color = new Color(news.color.r, news.color.g, news.color.b, 0);
        news.gameObject.SetActive(false);
        progressBar.gameObject.SetActive(false);
    }
    public void Show()
    {
        news.gameObject.SetActive(true);
        progressBar.gameObject.SetActive(true);
        title.gameObject.SetActive(true);
        for(int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].color = new Color(backgrounds[i].color.r, backgrounds[i].color.g, backgrounds[i].color.b, backAlpha[i]);
            backgrounds[i].gameObject.SetActive(true);
        }
        news.color = new Color(news.color.r, news.color.g, news.color.b, 1);
        title.color = new Color(title.color.r, title.color.g, title.color.b, 1);
    }
    public IEnumerator GetNews()
    {
        UnityWebRequest web = UnityWebRequest.Get(newsURL);
        progressBar.value = web.downloadProgress;
        yield return web.SendWebRequest();
        if (!web.isNetworkError)
        {
            Show();
            Destroy(progressBar.gameObject);
            news.text = web.downloadHandler.text;
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
