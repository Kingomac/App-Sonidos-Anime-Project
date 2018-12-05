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
	// Use this for initialization
	void Start () {
        initialPos = _sinopsis.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Cerrar()
    {
        _sinopsis.transform.position = initialPos;
        this.gameObject.SetActive(false);
    }

    public void SetText(int num)
    {
        _anime.text = anime[num];
        _sinopsis.text = sinopsis[num];
        UpdateHeight(num);
    }
    private void UpdateHeight(int num)
    {
        switch (num)
        {
            case 5: _sinopsis.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 7514.5f);
                break;
            default: _sinopsis.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 545.79f);
                break;
        }
    }
}
