using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallaDeCarga : MonoBehaviour
{
    public GameObject pantalla;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    IEnumerator LoadScene(string name)
    {
        pantalla.SetActive(true);
        yield return new WaitForSeconds(2);
        AsyncOperation a = SceneManager.LoadSceneAsync(name,LoadSceneMode.Additive);
        while (!a.isDone) yield return null;
        pantalla.SetActive(false);
        //Scene s = SceneManager.GetSceneByName(name);
        //SceneManager.SetActiveScene(s);
    }
    public void ChangeScene(string name)
    {
        StartCoroutine(LoadScene(name));
    }
}
