using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    public bool isActivated;
    [SerializeField] private bool isGoatColumn;
    [SerializeField] private bool isCowColumn;
    [SerializeField] private bool isPigColumn;
    [SerializeField] private GameObject headGameObject;
    [SerializeField] private string warningText;
    private bool isTriggered;
    private BlinkingText blinkingText;
    private bool addItemAble;
    private Inventory inventory;
    private void Start()
    {
        headGameObject.SetActive(false);
        blinkingText = FindAnyObjectByType<BlinkingText>();
        inventory = FindAnyObjectByType<Inventory>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isTriggered == true)
        {
            ColumnTrigger();
        }
    }
    private void ColumnTrigger() 
    {
        if (isGoatColumn && inventory.goatIsExisting)
        {
            isActivated = true;
            headGameObject.SetActive(true);
            inventory.RemoveItem(inventory.goatIndex);
        }
        else if (isCowColumn && inventory.cowIsExisting)
        {
            isActivated = true;
            headGameObject.SetActive(true);
            inventory.RemoveItem(inventory.cowIndex);
        }
        else if (isPigColumn && inventory.pigIsExisting)
        {
            isActivated = true;
            headGameObject.SetActive(true);
            inventory.RemoveItem(inventory.pigIndex);
        }
        else 
        {
            blinkingText.Blink(warningText);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            isTriggered = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            isTriggered = false;
        }
    }

}
