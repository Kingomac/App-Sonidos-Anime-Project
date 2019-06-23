using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

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
    }
    // Update is called once per frame
    void Update()
    {
        if (button.Pressed)
        {
            time += Time.deltaTime;
            if (time >= tiempoMantenerPulsado)
            {
                var a = Pantalla.GetComponent<DescripcionAnime>();
                a.Mostrar();
                a.SetText(animeNum);
            }
        }
        else
        {
            time = 0;
        }
    }
}