using UnityEngine;

public class NitroController : MonoBehaviour
{
    [Header("Configuraci�n del Nitro")]
    public float forwardShakeThreshold = 1.5f;  // Qu� tan fuerte hay que sacudir (ajustable)
    public float nitroDuration = 3f;            // Cu�nto dura el nitro
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
        // Detectar sacudida r�pida hacia adelante
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
        // Aqu� pod�s agregar efectos visuales/sonido si quer�s
    }

    void DeactivateNitro()
    {
        nitroActive = false;
        car.GetCarConfig.MaxMotorTorque /= nitroForceMultiplier;
        // Tambi�n podr�as apagar efectos visuales/sonido
    }
}
