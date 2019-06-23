using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PantallaDeCarga : MonoBehaviour
{
    public GameObject pantalla;
    public Image img;

    IEnumerator LoadScene(string name)
    {
        pantalla.SetActive(true);
        img.CrossFadeAlpha(255, 2, false);
        yield return new WaitForSeconds(1.5f);
        AsyncOperation a = SceneManager.LoadSceneAsync(name);
        while (!a.isDone) yield return null;
        pantalla.SetActive(false);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(name));
    }
    public void ChangeScene(string name)
    {
        StartCoroutine(LoadScene(name));
    }
}