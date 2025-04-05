using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] inventory = new GameObject[4];
    public GameObject[] cells = new GameObject[4];
    [Header("Existing things")]
    public bool cowIsExisting;
    public bool goatIsExisting;
    public bool pigIsExisting;
    [Header("Heads Index")]
    public int cowIndex;
    public int pigIndex;
    public int goatIndex;
    public void AddItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                GameObject newItem = Instantiate(item, cells[i].transform.position, Quaternion.identity);
                newItem.transform.parent = cells[i].transform;

                // Определение типа головы
                if (item.name.Contains("CowHead"))
                {
                    cowIsExisting = true;
                    cowIndex = i;
                }
                else if (item.name.Contains("GoatHead"))
                {
                    goatIsExisting = true;
                    goatIndex = i;
                }
                else if (item.name.Contains("PigHead"))
                {
                    pigIsExisting = true;
                    pigIndex = i;
                }

                Debug.Log($"Предмет добавлен в ячейку {i}");
                return;
            }
        }
        Debug.Log("Инвентарь полон, невозможно добавить предмет.");
    }
    public void RemoveItem(int index)
    {
        if (index < 0 || index >= inventory.Length)
        {
            Debug.LogWarning("Недопустимый индекс ячейки.");
            return;
        }

        if (inventory[index] == null)
        {
            Debug.Log("В ячейке нет предмета для удаления.");
            return;
        }

        // Сброс флагов существования
        if (index == cowIndex)
            cowIsExisting = false;
        else if (index == goatIndex)
            goatIsExisting = false;
        else if (index == pigIndex)
            pigIsExisting = false;

        // Удаляем визуал из UI ячейки
        if (cells[index].transform.childCount > 0)
        {
            Destroy(cells[index].transform.GetChild(0).gameObject);
        }

        // Удаляем из массива
        inventory[index] = null;

        Debug.Log($"Предмет из ячейки {index} удалён.");
    }

}
