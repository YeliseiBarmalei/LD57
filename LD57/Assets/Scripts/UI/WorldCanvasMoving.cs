using UnityEngine;

public class WorldCanvasMoving : MonoBehaviour
{
    private Transform playerTransform;

    void Start()
    {
        // Поиск объекта с компонентом PlayerController
        PlayerController player = FindAnyObjectByType<PlayerController>();

        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("PlayerController не найден!");
        }
    }

    void Update()
    {
        if (playerTransform != null)
        {
            // Двигаем Canvas к позиции игрока
            transform.position = playerTransform.position;
        }
    }
}
