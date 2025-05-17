using UnityEngine;

public class NitroController : MonoBehaviour
{
    [Header("Configuración del Nitro")]
    public float forwardShakeThreshold = 1.5f;  // Qué tan fuerte hay que sacudir (ajustable)
    public float nitroDuration = 3f;            // Cuánto dura el nitro
    public float nitroForceMultiplier = 1.5f;   // Multiplicador de fuerza/motor

    private bool nitroActive = false;
    private float nitroTimer = 0f;

    private CarController car; // Tu controlador del auto

    void Start()
    {
        car = GetComponent<CarController>();
    }

    void Update()
    {
        DetectForwardShake();

        if (nitroActive)
        {
            nitroTimer -= Time.deltaTime;
            if (nitroTimer <= 0f)
            {
                DeactivateNitro();
            }
        }
    }

    void DetectForwardShake()
    {
        // Detectar sacudida rápida hacia adelante
        if (!nitroActive && Input.acceleration.z > forwardShakeThreshold)
        {
            ActivateNitro();
        }
    }

    void ActivateNitro()
    {
        nitroActive = true;
        nitroTimer = nitroDuration;
        car.GetCarConfig.MaxMotorTorque *= nitroForceMultiplier;
        // Aquí podés agregar efectos visuales/sonido si querés
    }

    void DeactivateNitro()
    {
        nitroActive = false;
        car.GetCarConfig.MaxMotorTorque /= nitroForceMultiplier;
        // También podrías apagar efectos visuales/sonido
    }
}
