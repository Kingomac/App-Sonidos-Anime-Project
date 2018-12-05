using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarDescripcion : MonoBehaviour
{

    public GameObject Pantalla;
    [Range(0.5f, 5f)]
    public float tiempoMantenerPulsado;
    public int animeNum;
    [Range(5f, 15f)]
    protected float time = 0;
    protected FixedButton button;
    // Use this for initialization
    void Start()
    {
        button = GetComponent<FixedButton>();
        SetFinalFondos();
    }
    // Update is called once per frame
    void Update()
    {
        if (button.Pressed)
        {
            HideAll();
            time += Time.deltaTime;
            if (time >= tiempoMantenerPulsado)
            {
                Pantalla.SetActive(true);
                StartCoroutine(Animation(false));
                try { Pantalla.GetComponent<DescripcionAnime>().SetText(animeNum); }
                catch { Pantalla.GetComponent<DescripcionSonido>().SetText(animeNum); }
            }
        }
        else
        {
            time = 0;
        }
    }
    [Range(0.01f,1f)]
    public float velocidadAnimacion;
    public Image[] fondos;
    public Text[] textos;
    private Color[] finalFondos;
    private Color[] finalTextos;
    public IEnumerator Animation(bool showed)
    {
        for(int i = 0; i < fondos.Length; i++)
        {
            //Transición para el fondo 0
            Color c = new Color(finalFondos[i].r, finalFondos[i].g, finalFondos[i].b, 0);
            while (c.a < finalFondos[i].a)
            {
                fondos[i].color = c;
                c.a += velocidadAnimacion;
                yield return null;
            }
            fondos[i].color = finalFondos[i];
        }
        for(int i = 0; i < textos.Length; i++)
        {
            //Transición para el fondo 0
            Color c = new Color(finalTextos[i].r, finalTextos[i].g, finalTextos[i].b, 0);
            while (c.a < finalTextos[i].a)
            {
                textos[i].color = c;
                c.a += velocidadAnimacion;
                yield return null;
            }
            textos[i].color = finalTextos[i];
        }
    }
    public void HideAll()
    {
        for (int i = 0; i < fondos.Length; i++)
        {
            Color final = fondos[i].color;
            Color c = new Color(final.r, final.g, final.b, 0);
            fondos[i].color = c;
        }
        for (int i = 0; i < textos.Length; i++)
        {
            Color final = textos[i].color;
            Color c = new Color(final.r, final.g, final.b, 0);
            textos[i].color = c;
        }
    }
    public void SetFinalFondos()
    {
        finalFondos = new Color[fondos.Length];
        for (int i = 0; i < fondos.Length; i++)
        {
            finalFondos[i] = fondos[i].color;
        }
        finalTextos = new Color[textos.Length];
        for(int i = 0; i < textos.Length; i++)
        {
            finalTextos[i] = textos[i].color;
        }
    }
}