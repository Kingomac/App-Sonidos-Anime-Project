using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PantallaDeCarga : MonoBehaviour
{

    public static PantallaDeCarga Instancia { get; private set; }

    public Image imageDeCarga;
    [Range(0.01f, 0.5f)]
    public float velocidad = 0.5f;

    void Awake()
    {
        DefinirSingleton();
    }

    private void DefinirSingleton()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(this);
            imageDeCarga.gameObject.SetActive(false);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CargarEscena(string nombreEscena)
    {
        StartCoroutine(MostrarPantallaDeCarga(nombreEscena));
    }


    private IEnumerator MostrarPantallaDeCarga(string nombreEscena)
    {
        imageDeCarga.gameObject.SetActive(true);
        Color c = imageDeCarga.color;
        c.a = 0.0f;

        //Mientras no esté totalmente visible va aumentando su visibilidad
        while (c.a < 1)
        {
            imageDeCarga.color = c;
            c.a += velocidad;
            yield return null;
        }
        c.a = 1;
        imageDeCarga.color = c;
        //Carga la escena
        SceneManager.LoadSceneAsync(nombreEscena);

        //Espera a que haya cargado la nueva escena
        while (!nombreEscena.Equals(SceneManager.GetActiveScene().name))
        {
            yield return null;
        }

        //Mientras la imagen de carga siga visible va desvaneciéndola
        while (c.a > 0)
        {
            imageDeCarga.color = c;
            c.a -= velocidad;
            yield return null;
        }
        imageDeCarga.gameObject.SetActive(false);
    }
}