using UnityEngine;
using UnityEngine.InputSystem;

public class VehicleActor : MonoBehaviour
{
    [Header("Настройки")]
    public Vehicle settingsData;

    private bool currentEngineState;

    private Rigidbody rb;
    private float moveInput;
    private float turnInput;
    private Vector3 BodyRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null) Debug.LogError("Rigidbody is empty");

        if (settingsData != null)
        {
            currentEngineState = settingsData.IsEngineOn;
        }


        // Data setup

        rb.mass = settingsData.VehicleMass;

        //

        EngineSetup();
    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        float forward = keyboard.wKey.isPressed ? 1f : 0f;
        float backward = keyboard.sKey.isPressed ? 1f : 0f;
        moveInput = forward - backward;

        float right = keyboard.dKey.isPressed ? 1f : 0f;
        float left = keyboard.aKey.isPressed ? 1f : 0f;
        turnInput = right - left;
    }

    void FixedUpdate()
    {
        ApplyMovement();
    }

    private void SetChassisParts()
    {

    }

    private void EngineSetup()
    {
        currentEngineState = !currentEngineState;
    }

    void ApplyMovement()
    {
        if (settingsData == null) return;

        // Рассчитываем вектор направления (вперед/назад)
        Vector3 forceDirection = transform.forward * moveInput;

        // Прикладываем силу
        // В Unity AddForce принимает (Вектор силы * Значение скорости)
        rb.AddForce(forceDirection * settingsData.MaxVehicleSpeed, ForceMode.Acceleration);

        // Для поворота (опционально) используем крутящий момент
        if (turnInput != 0)
        {
            Quaternion deltaRotation = Quaternion.Euler(BodyRotation * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }
}
