using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHp = 10;
    public int currentHp = 10;
    public GameObject eButton;
    [SerializeField] private float numberOfFuel = 20f;
    [SerializeField] private Text hpText;
    private FuelSystem fuelSystem;
    private void Start()
    {
        currentHp = maxHp;
        fuelSystem = FindAnyObjectByType<FuelSystem>();
    }
    private void Update()
    {
        hpText.text = currentHp.ToString();
        if (currentHp <= 0) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
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
