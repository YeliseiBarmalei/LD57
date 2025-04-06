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
    [SerializeField] private string haveNoHeadText;
    [SerializeField] private string differentHeadText;
    private bool isTriggered;
    private BlinkingText blinkingText;
    private bool addItemAble;
    private Inventory inventory;
    private bool triggerScriptIsDestroyed = false;
    private Player player;
    private void Start()
    {
        player = FindAnyObjectByType<Player>();
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
        if(isActivated == false)
        if (isGoatColumn && inventory.goatIsExisting)
        {
            isActivated = true;
            headGameObject.SetActive(true);
            inventory.RemoveItem(inventory.goatIndex);
            Destroy(GetComponent<TriggerObject>());
            triggerScriptIsDestroyed = true;
            player.eButton.SetActive(false);
        }
        else if (isCowColumn && inventory.cowIsExisting)
        {
            isActivated = true;
            headGameObject.SetActive(true);
            inventory.RemoveItem(inventory.cowIndex);
            Destroy(GetComponent<TriggerObject>());
            triggerScriptIsDestroyed = true;
            player.eButton.SetActive(false);
            }
        else if (isPigColumn && inventory.pigIsExisting)
        {
            isActivated = true;
            headGameObject.SetActive(true);
            inventory.RemoveItem(inventory.pigIndex);
            Destroy(GetComponent<TriggerObject>());
            triggerScriptIsDestroyed = true;
            player.eButton.SetActive(false);
            }
        else if (!inventory.pigIsExisting && !inventory.goatIsExisting && !inventory.cowIsExisting )
        {
            if (triggerScriptIsDestroyed == false)
                {
                    blinkingText.Blink(haveNoHeadText);
                }
        }
        else 
        {
                if (triggerScriptIsDestroyed == false)
                {
                    blinkingText.Blink(differentHeadText);
                }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            isTriggered = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            isTriggered = false;
        }
    }

}
