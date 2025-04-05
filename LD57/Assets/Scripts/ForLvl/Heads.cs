using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heads : MonoBehaviour
{
    [Header("Heads")]
    [SerializeField] private GameObject CowHeadImage;
    [SerializeField] private GameObject PigHeadImage;
    [SerializeField] private GameObject GoutHeadImage;
    [Header("Bools")]
    [SerializeField] private bool isCowHead;
    [SerializeField] private bool isPigHead;
    [SerializeField] private bool isGoutHead;
    [Header("Other")]
    private Player player;
    private Inventory inventory;
    private bool addItemAble = false;
    private void Start()
    {
        inventory = FindAnyObjectByType<Inventory>();
        player = FindAnyObjectByType<Player>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && addItemAble)
        {
            addItemAble = false;
            if (isCowHead)
            {
                inventory.AddItem(CowHeadImage);
                //inventory.cowIsExisting = true;
                Destroy(gameObject);
            }
            else if (isPigHead)
            {
                inventory.AddItem(PigHeadImage);
                Destroy(gameObject);
                //inventory.pigIsExisting = true;
            }
            else if (isGoutHead)
            {
                //inventory.goatIsExisting = true;
                inventory.AddItem(GoutHeadImage);
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            addItemAble = true;
            player.eButton.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            addItemAble = false;
            player.eButton.SetActive(false);
        }
    }
}
