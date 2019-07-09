using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescripcionAnime : MonoBehaviour {
    public string[] anime;
    public string[] sinopsis;
    public Text _anime;
    public Text _sinopsis;
    private Vector3 initialPos;
    public Image[] img;
	// Use this for initialization
	void Start () {
        initialPos = _sinopsis.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetText(int num)
    {
        _anime.text = anime[num];
        _sinopsis.text = sinopsis[num];
        UpdateHeight(num);
    }
    private void UpdateHeight(int num)
    {
        _sinopsis.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 545.79f);
    }
    public void Mostrar()
    {
        gameObject.SetActive(true);
        foreach (Image i in img)
        {
            i.CrossFadeAlpha(255, 5, false);
        }
    }
    public void Ocultar()
    {
        _sinopsis.transform.position = initialPos;
        foreach (Image i in img)
        {
            i.CrossFadeAlpha(1, 5, false);
        }
        gameObject.SetActive(false);
    }
}
