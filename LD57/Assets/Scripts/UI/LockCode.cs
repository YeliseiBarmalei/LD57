using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockCode : MonoBehaviour
{
    [SerializeField] private CombinationLock[] lockers;
    [Header("Code")]
    public int[] correctCode = new int[4];

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

        Debug.Log("✅ Код верный! Открываем замок!");
        // Здесь можешь вызвать метод открытия двери или чего угодно
    }
}
