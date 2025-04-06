using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombinationLock : MonoBehaviour
{
    public int currentNumber = 0;
    public Text text;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = gameObject.GetComponentInParent<AudioSource>();
        text = GetComponentInChildren<Text>();
    }
    public void AddPoint() 
    {
        if (currentNumber < 9)
        {
            audioSource.PlayOneShot(audioSource.clip);
            currentNumber++;
            text.text = currentNumber.ToString();
        }
    }
    public void DeductAPoint() 
    {
        if (currentNumber > 0)
        {
            audioSource.PlayOneShot(audioSource.clip);
            currentNumber--;
            text.text = currentNumber.ToString();
        }
    }
}
