using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour
{
    [SerializeField] private float blinkDuration = 2f;
    [SerializeField] private float blinkInterval = 0.2f;
    private Text warningText;
    private void Start()
    {
        warningText = GetComponent<Text>();
    }
    public void Blink(string message)
    {
        StopAllCoroutines(); // Чтобы не наслаивались вызовы
        StartCoroutine(BlinkRoutine(message));
    }

    private IEnumerator BlinkRoutine(string message)
    {
        warningText.text = message;
        float elapsed = 0f;

        while (elapsed < blinkDuration)
        {
            warningText.enabled = !warningText.enabled;
            yield return new WaitForSeconds(blinkInterval);
            elapsed += blinkInterval;
        }

        warningText.enabled = false;
    }
}
