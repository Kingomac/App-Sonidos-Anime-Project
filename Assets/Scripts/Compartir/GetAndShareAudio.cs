using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetAndShareAudio : MonoBehaviour
{
    public DescripcionSonido descSonido;
    public Button[] buttons;
    public FixedButton[] fixedbuttons;
    public AudioSource[] audios;
    public string[] songlinks;
    public string[] soundName;
    // Start is called before the first frame update
    void Awake()
    {
        buttons = GetComponentsInChildren<Button>();
        fixedbuttons = GetComponentsInChildren<FixedButton>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
