using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombinationLock : MonoBehaviour
{
    public int currentNumber = 0;
    public Text text;
    private void Start()
    {
        text = GetComponentInChildren<Text>();
    }
    public void AddPoint() 
    {
        if (currentNumber < 9)
        {
            currentNumber++;
            text.text = currentNumber.ToString();
        }
    }
    public void DeductAPoint() 
    {
        if (currentNumber > 0)
        {
            currentNumber--;
            text.text = currentNumber.ToString();
        }
    }
}
