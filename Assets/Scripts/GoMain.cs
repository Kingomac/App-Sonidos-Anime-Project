using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoMain : MonoBehaviour
{
    public void GoBack(string name)
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        FindObjectOfType<PantallaDeCarga>().ChangeScene(name);
    }
    public void Main()
    {
        FindObjectOfType<PantallaDeCarga>().ChangeScene("Main");
    }
}
