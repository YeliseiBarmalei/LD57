using UnityEngine;

public class DistanceSound2D : MonoBehaviour
{
    [SerializeField] private float maxDistance = 10f;
    private Transform player;           // Сюда перетащи объект игрока в инспекторе
    private AudioSource audioSource;
    // На каком расстоянии громкость = 0

    void Start()
    {
        player = FindAnyObjectByType<Player>().transform;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        // Рассчитываем громкость: ближе = громче
        float volume = 0.65f - Mathf.Clamp01(distance / maxDistance);
        audioSource.volume = volume;
    }
}
