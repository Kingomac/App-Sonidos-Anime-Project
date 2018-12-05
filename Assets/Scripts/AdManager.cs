using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class AdManager : MonoBehaviour {

    public static AdManager instancia;
    public void Start()
    {
        //Singleton pattern
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instancia != this)
        {
            Destroy(gameObject);
            return;
        } 
    }
    public void Update()
    {
        //Comprobación y anuncios
        SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
    }

    private void SceneManager_activeSceneChanged(Scene prev, Scene active)
    {
        if (Random.Range(0, 5000) == 10) MostrarAnuncio();
    }

    public static void MostrarAnuncio()
    {
        if(Advertisement.IsReady()) Advertisement.Show();
    }
    public static void MostrarBanner()
    {
        if (Advertisement.IsReady()) Advertisement.Show("banner");
    }
}
