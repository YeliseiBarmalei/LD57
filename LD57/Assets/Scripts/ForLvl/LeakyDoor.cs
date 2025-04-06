using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeakyDoor : MonoBehaviour
{
    [SerializeField] private float moveDistance = 2f;
    [SerializeField] private float moveDuration = 1f;
    [SerializeField] private Column[] columns;
    public bool isCloset = true;
    private void Update()
    {
        if (AllColumnsActivated())
        {
            OpenDoor();
        }
    }

    private bool AllColumnsActivated()
    {
        foreach (Column col in columns)
        {
            if (!col.isActivated)
                return false;
        }
        return true;
    }
    private void OpenDoor()
    {
        transform.DOMoveX(transform.position.x - moveDistance, moveDuration);
        TurnOffColumns();
        isCloset = false;
    }
    private void TurnOffColumns()
    {
        foreach (Column col in columns)
        {
            col.isActivated = false;
        }
    }
    public void CloseDoor()
    {
        transform.DOMoveX(transform.position.x + moveDistance, moveDuration);
        isCloset = true;
    }

}