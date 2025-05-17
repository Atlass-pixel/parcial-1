using UnityEngine;
using TMPro;
using System.Collections;

public class Checkpoint : MonoBehaviour
{
    public float extraTime = 15f;                      // Tiempo a sumar 
    public TextMeshProUGUI feedbackText;               // +15 segundos
    public float messageDuration = 3f;                 // Cuánto tiempo mostrar mensaje

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            // Suma tiempo al contador 
            FindObjectOfType<TimeManager>()?.AddTime(extraTime);

            // Mostrar mensaje "+15 segundos"
            if (feedbackText != null)
            {
                feedbackText.text = $"+{extraTime} segundos";
                feedbackText.gameObject.SetActive(true);
                StartCoroutine(HideMessageAfterDelay());
            }

            
            // Destroy(gameObject);
        }
    }

    private IEnumerator HideMessageAfterDelay()
    {
        yield return new WaitForSeconds(messageDuration);
        if (feedbackText != null)
        {
            feedbackText.gameObject.SetActive(false);
        }
    }
}
