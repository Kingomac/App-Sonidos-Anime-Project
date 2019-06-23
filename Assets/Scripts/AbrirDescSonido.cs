using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirDescSonido : MonoBehaviour
{
    private FixedButton fb;
    private float timer;
    [Range(1,3)]
    public float tiempoClick;
    public string scene;
    // Start is called before the first frame update
    void Start()
    {
        fb = GetComponent<FixedButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fb.Pressed)
        {
            timer += Time.deltaTime;
            if (timer >= tiempoClick) FindObjectOfType<PantallaDeCarga>().ChangeScene(scene);
        }
        else
        {
            timer = 0;
        }
    }
}
