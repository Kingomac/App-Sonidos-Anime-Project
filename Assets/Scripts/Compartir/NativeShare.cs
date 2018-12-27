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
    public GameObject[] PlayShareWindow;
    public GameObject[] SoundButtons;
    public void ShowSharePlay()
    {
        PlayShareWindow[descripcionSonido.animenum].SetActive(true);
        GameObject.Find("DescripcionAnime").SetActive(false);
        HideOtherSoundButtons(PlayShareWindow[descripcionSonido.animenum].transform.parent.gameObject);
    }
    public void HideOtherSoundButtons(GameObject thisgameObject)
    {
        SoundButtons = GameObject.FindGameObjectsWithTag("SoundButton");
        foreach (GameObject i in SoundButtons)
        {
            if (i != thisgameObject) i.SetActive(false);
        }
    }
    public void ShowSoundButtons()
    {
        foreach (GameObject i in SoundButtons)
        {
            i.SetActive(true);
        }
        SoundButtons = null;
    }
}