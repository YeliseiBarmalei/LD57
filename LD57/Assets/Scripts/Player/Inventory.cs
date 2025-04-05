using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] inventory = new GameObject[4];
    public GameObject[] cells = new GameObject[4];
    public void AddItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                GameObject newItem = Instantiate(item,cells[i].transform.position,Quaternion.identity);
                newItem.transform.parent = cells[i].transform;
                Debug.Log($"Предмет добавлен в ячейку {i}");
                return;
            }
        }
        Debug.Log("Инвентарь полон, невозможно добавить предмет.");
    }

}
