using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class ShareMiraiNikki : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator Share(string link)
    {
        UnityWebRequest www = UnityWebRequest.Get(link);
        yield return www.SendWebRequest();
        File.WriteAllBytes(Application.temporaryCachePath + "/sound.mp3",www.downloadHandler.data);
    }
}
