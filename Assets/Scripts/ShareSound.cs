using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using NatShareU;
using System.IO;

public class ShareSound : MonoBehaviour
{
    private FixedButton button;
    private float timer;
    [Range(1,3)]
    public float tiempoEspera;
    public string link;
    private int num;
    private bool executed = false;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<FixedButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if (button.Pressed)
        {
            timer += Time.deltaTime;
            if(timer >= tiempoEspera && !executed)
            {
                StartCoroutine(Compartir());
                executed = true;
            }
        }
        else
        {
            num = Random.Range(-100, 100);
            timer = 0;
            executed = false;
        }
    }
    private IEnumerator Compartir()
    {
        UnityWebRequest www = UnityWebRequest.Get(link);
        string result = Path.Combine(Application.temporaryCachePath, $"{num}.mp3");
        yield return www.SendWebRequest();
        if(www.isNetworkError || www.isHttpError)
        {
            Debug.Log("Network error: " + www.error);
        }
        if (www.isDone)
        {
            File.WriteAllBytes(result, www.downloadHandler.data);
            NatShare.ShareMedia(result);
            Debug.Log("File downloaded in: " + result);
        }
    }
}
