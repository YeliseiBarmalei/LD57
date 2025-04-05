using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISceneLoader : MonoBehaviour
{
    public void ButtonSceneLoader(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ThisSceneLoader() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Exit() 
    {
        Application.Quit();
    }
}
