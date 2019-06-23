using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescripcionSonido : MonoBehaviour {
    public string[] anime;
    public Text _anime;
    public int animenum;
    public Image[] img;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Cerrar()
    {
        foreach(Image i in img)
        {
            i.CrossFadeAlpha(1, 5, false);
        }
        gameObject.SetActive(false);
    }

    public void SetText(int num)
    {
        _anime.text = anime[num];
        animenum = num;
    }
    public void Mostrar()
    {
        foreach(Image i in img)
        {
            i.CrossFadeAlpha(255, 5, false);
        }
    }
}
