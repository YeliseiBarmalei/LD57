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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fuel"))
        {
            Debug.Log("OnTriggerEnter2D");
            fuelSystem.currentFuel += numberOfFuel;
            Destroy(collision.gameObject);
        }
    }
}
