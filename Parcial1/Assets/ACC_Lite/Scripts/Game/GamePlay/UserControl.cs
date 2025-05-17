using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarController))]
public class UserControl : MonoBehaviour
{
    CarController ControlledCar;

    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public bool Brake { get; private set; }

    public static MobileControlUI CurrentUIControl { get; set; }

    [SerializeField] float tiltSensitivity = 3f; // más alto = más sensible
    [SerializeField] float tiltSmoothing = 5f;   // más alto = más suave

    void Awake()
    {
        ControlledCar = GetComponent<CarController>();
        CurrentUIControl = FindObjectOfType<MobileControlUI>();
    }

    void Update()
    {
        if (CurrentUIControl != null && CurrentUIControl.ControlInUse)
        {
            // acelerador y freno desde botones UI
            Vertical = CurrentUIControl.GetVerticalAxis;
            Brake = false; // asumimos que tenés un botón de freno separado si querés

            // inclinación lateral para girar
            float rawTilt = Input.acceleration.x; // entre -1 (izq) y 1 (der)
            float target = Mathf.Clamp(rawTilt * tiltSensitivity, -1f, 1f);
            Horizontal = Mathf.Lerp(Horizontal, target, Time.deltaTime * tiltSmoothing);
        }
        else
        {
            // control con teclado/gamepad
            Horizontal = Input.GetAxis("Horizontal");
            Vertical = Input.GetAxis("Vertical");
            Brake = Input.GetButton("Jump");
        }

        ControlledCar.UpdateControls(Horizontal, Vertical, Brake);
    }
}
