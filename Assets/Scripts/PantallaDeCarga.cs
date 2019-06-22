using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PantallaDeCarga : MonoBehaviour
{
    public GameObject pantalla;
    public Image img;
    public float a;
    // Start is called before the first frame update
    void Start()
    {
        img = pantalla.GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    IEnumerator LoadScene(string name)
    {
        pantalla.SetActive(true);
        img.CrossFadeAlpha(255, 2, false);
        yield return new WaitForSeconds(2);
        AsyncOperation a = SceneManager.LoadSceneAsync(name,LoadSceneMode.Additive);
        while (!a.isDone) yield return null;
        pantalla.SetActive(false);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(name));
        img.color = new Color(img.color.r, img.color.g, img.color.b, 0);
    }
    public void ChangeScene(string name)
    {
        StartCoroutine(LoadScene(name));
    }
}