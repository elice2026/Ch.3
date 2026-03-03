using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_Manager : MonoBehaviour
{
    public void RePlay()
    {
        SceneManager.LoadScene("PlayScene");
    }
    public void BtnQuit()
    {
        Application.Quit();
    }
}
