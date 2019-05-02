using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayRandomMiriaNikki : MonoBehaviour
{
    private Image imagen;
    public Sprite[] sprites;
    public AudioClip[] audios;
    private AudioSource sonido;
    // Start is called before the first frame update
    void Start()
    {
        imagen = GetComponent<Image>();
        sonido = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Stop()
    {
        //Detener audio
        try
        {
            sonido.Stop();
        }
        catch
        {
        }
    }
    public void Click()
    {
        Stop();
        //Reproducir nuevo audio
        sonido.clip = audios[Random.Range(0, audios.Length)];
        sonido.Play();
        //Cambiar sprite
        imagen.sprite = sprites[Random.Range(0, sprites.Length)];
    }
    public void Play(int num)
    {
        sonido.clip = audios[num];
        sonido.Play();
    }
}
