using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject eButton;
    [SerializeField] private float numberOfFuel = 20f;
    private FuelSystem fuelSystem;
    private void Start()
    {
        fuelSystem = FindAnyObjectByType<FuelSystem>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out TriggerObject triggerObject ))
        {
            eButton.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out  TriggerObject triggerObject))
        {
            eButton.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Fuel"))
        {
            Debug.Log("OnTriggerEnter2D");
            fuelSystem.currentFuel += numberOfFuel;
            Destroy(collision.gameObject);
        }

    }
}
