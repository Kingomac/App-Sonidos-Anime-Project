using UnityEngine;
using System.Collections;
using System.IO;
using NatShareU.Docs;
using NatShareU;
using NatShareU.Platforms;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class NativeShare : MonoBehaviour
{
    public DescripcionSonido descripcionSonido;
    public GameObject[] ShareWindow;
    public GameObject[] PlayWindow;
    public string[] links;
    private string filepath;
    protected string songlink;
    private void Start()
    {
        filepath = Application.temporaryCachePath + "/sound.mp3";
    }
    private void Update()
    {
        
    }
    public void ShareText()
    {
        string text = "Que bien me lo paso con la maravillosa App de Sonidos de Anime, acabo de escuchar: " + descripcionSonido._anime.text;
        NatShare.ShareText(text);
    }
    public void ShowShareWindow()
    {
        ShareWindow[descripcionSonido.animenum].SetActive(true);
        GameObject.Find("DescripcionAnime").SetActive(false);
    }
    public void ShowPlayWindow()
    {
        PlayWindow[descripcionSonido.animenum].SetActive(true);
        GameObject.Find("DescripcionAnime").SetActive(false);
    }
    public void ShareSong()
    {
        StartCoroutine(ShareSongCore(descripcionSonido.animenum));
    }
    public IEnumerator ShareSongCore(int animenum)
    {
        GetLinksList(animenum);
        UnityWebRequest www = UnityWebRequest.Get(songlink);
        yield return www.SendWebRequest();
        File.WriteAllBytes(filepath, www.downloadHandler.data);
        NatShare.ShareMedia(filepath);
    }
    public void GetLinksList(int animenum)
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "EromangaSensei": switch (animenum)
                {
                    case 0:
                        songlink = "https://raw.githubusercontent.com/Kingomac/AppSonidosAnime/master/sounds/eromanga-sensei/chichidaisuki.mp3";
                        break;
                    case 1: StartCoroutine(GetRandomSongLink("https://raw.githubusercontent.com/Kingomac/AppSonidosAnime/master/sounds/eromanga-sensei/baka.txt"));
                        break;
                }
                break;
            case "BlackClover": switch (animenum)
                {
                    case 0: StartCoroutine(GetRandomSongLink("https://raw.githubusercontent.com/Kingomac/AppSonidosAnime/master/sounds/blackclover.txt"));
                        break;
                    case 1: songlink = "https://raw.githubusercontent.com/Kingomac/AppSonidosAnime/master/sounds/blackclover/remix.mp3";
                        break;
                }
                break;
            case "BokuNoHero": switch (animenum)
                {
                    case 0: songlink = "https://raw.githubusercontent.com/Kingomac/AppSonidosAnime/master/sounds/bokunohero/bakugou/Remix.mp3";
                        break;
                    case 1: StartCoroutine(GetRandomSongLink("https://raw.githubusercontent.com/Kingomac/AppSonidosAnime/master/sounds/bokunohero/bakugou.txt"));
                        break;
                    case 2: StartCoroutine(GetRandomSongLink("https://raw.githubusercontent.com/Kingomac/AppSonidosAnime/master/sounds/bokunohero/allmightsmash.txt"));
                        break;
                    case 3: StartCoroutine(GetRandomSongLink("https://raw.githubusercontent.com/Kingomac/AppSonidosAnime/master/sounds/bokunohero/DekuSmash"));
                        break;
                    case 4: StartCoroutine(GetRandomSongLink("https://raw.githubusercontent.com/Kingomac/AppSonidosAnime/master/sounds/bokunohero/Deku.txt"));
                        break;
                }
                break;
            case "Konosuba": switch (animenum)
                {
                    case 0: StartCoroutine(GetRandomSongLink("https://raw.githubusercontent.com/Kingomac/AppSonidosAnime/master/sounds/konosuba.txt"));
                        break;
                    case 1: songlink = "https://raw.githubusercontent.com/Kingomac/AppSonidosAnime/master/sounds/konosuba/jajajajaja.mp3";
                        break;
                }
                break;
            case "LoveLiveSunshine": switch (animenum)
                {
                    case 0: StartCoroutine(GetRandomSongLink("https://raw.githubusercontent.com/Kingomac/AppSonidosAnime/master/sounds/llsunshine/ganbaruby.txt"));
                        break;
                    case 1: StartCoroutine(GetRandomSongLink("https://raw.githubusercontent.com/Kingomac/AppSonidosAnime/master/sounds/llsunshine/yousoro.txt"));
                        break;
                }
                break;
        }
    }
    public IEnumerator GetRandomSongLink(string linklist)
    {
        UnityWebRequest www = UnityWebRequest.Get(linklist);
        yield return www.SendWebRequest();
        links = www.downloadHandler.text.Split('\n');
        songlink = links[Random.Range(0, links.Length)];
    }
}