using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningWindowsOnAndOff : MonoBehaviour
{
    public void OpenWindow() 
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void CloseWindow()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void OpenAndCloseWindow()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
