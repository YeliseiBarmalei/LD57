using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerDoor : MonoBehaviour
{
    [SerializeField] private bool isVectorXDoor;
    [SerializeField] private bool isVectorYDoor;
    [SerializeField] private float moveDistance = 2f;
    [SerializeField] private float moveDuration = 1f;
    public void OpenDoor()
    {
        if (isVectorXDoor) 
        {
            transform.DOMoveX(transform.position.x - moveDistance, moveDuration);
        }
        if (isVectorYDoor)
        {
            transform.DOMoveY(transform.position.y - moveDistance, moveDuration);
        }
        else 
        {
            Debug.LogWarning("НЕ НАЗНАЧИЛ БУЛЫ");
        }
       
    }
}
