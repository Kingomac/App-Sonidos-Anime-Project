using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsController: MonoBehaviour{

    public bool newsShowed;
    public static NewsController instancia;
    // Use this for initialization
    public void Start () {
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
	
	// Update is called once per frame
	void Update () {
		
	}
}
