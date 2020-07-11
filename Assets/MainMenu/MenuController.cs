using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void OnStart() {
        SceneManager.LoadScene("CoryScene");
    }

    public void OnQuit() {
        Application.Quit();
    }
}
