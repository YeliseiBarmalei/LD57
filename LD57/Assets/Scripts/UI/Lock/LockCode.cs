using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockCode : MonoBehaviour
{
    [SerializeField] private CombinationLock[] lockers;
    [SerializeField] private LockerDoor[] lockerDoors;
    [Header("Code")]
    public int[] correctCode = new int[4];
    public bool codeIsCorrect = false;

    private void Update()
    {
        if (gameObject.activeSelf == true)
        {
            Time.timeScale = 0f;
        }
        else if (gameObject.activeSelf == false)
        {
            Time.timeScale = 1f;
        }
    }
    public void ReturnToZero() 
    {
        for (int i = 0; i < lockers.Length; i++)
        {
            lockers[i].currentNumber = 0;
            lockers[i].text.text = lockers[i].currentNumber.ToString();
        }
    }
    public void CheckCode()
    {
        for (int i = 0; i < lockers.Length; i++)
        {
            if (lockers[i].currentNumber != correctCode[i])
            {
                Debug.Log("Неправильный код");
                return;
            }
        }
        CorrectCode();
    }
    private void CorrectCode() 
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        for (int i = 0; i < lockerDoors.Length; i++)
        {
            lockerDoors[i].OpenDoor();
        }
        codeIsCorrect = true;


    }
}
