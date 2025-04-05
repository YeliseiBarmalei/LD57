using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelSystem : MonoBehaviour
{
    public float currentFuel;
    [SerializeField] private float maxFuel;
    [SerializeField] private GameObject[] lightings;
    private Image barImage;
    void Start()
    {
        currentFuel = maxFuel;
        barImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        currentFuel = Mathf.Max(0, currentFuel - Time.deltaTime);
        barImage.fillAmount = currentFuel / maxFuel;
        if (currentFuel> maxFuel) 
        {
            currentFuel = maxFuel;
        }
        if (currentFuel <= 0)
        {
            foreach (GameObject light in lightings)
            {
                light.SetActive(false);
            }
        }
        else if (currentFuel > 0) 
        {
            foreach (GameObject light in lightings)
            {
                light.SetActive(true);
            }
        }
    }
}
