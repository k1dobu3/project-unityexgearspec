using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VehicleController : MonoBehaviour
{
    [Header("Настройки")]
    [SerializeField] private Vehicle settingsData;

    private Rigidbody rb;
    private VehicleModel model;
    private IVehicleInput input;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        model = new VehicleModel(settingsData);
        input = new KeyboardVehicleInput();

        if (settingsData != null)
            rb.mass = settingsData.VehicleMass;

        // Подписка на события модели
        model.OnEngineStateChanged += OnEngineStateChanged;
    }

    private void Update()
    {
        if (GameManager.Instance.CurrentState != GameState.Playing) return;

        input.Update();                    // обновляем ввод

        if (input.EngineTogglePressed)
            model.ToggleEngine();
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.CurrentState != GameState.Playing || !model.IsEngineOn)
            return;

        ApplyMovement();
    }

    private void ApplyMovement()
    {
        // Движение вперёд/назад
        Vector3 forceDirection = transform.forward * input.MoveInput;
        rb.AddForce(forceDirection * settingsData.MaxVehicleSpeed, ForceMode.Acceleration);

        // Поворот (исправленная версия)
        if (Mathf.Abs(input.TurnInput) > 0.01f)
        {
            float turnAmount = input.TurnInput * settingsData.TurnSpeed * Time.fixedDeltaTime;
            Quaternion deltaRotation = Quaternion.Euler(0, turnAmount, 0);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }

    private void OnEngineStateChanged(bool isOn)
    {
        Debug.Log($"Двигатель: {(isOn ? "ВКЛ" : "ВЫКЛ")}");
        // Здесь можно запустить звук, частицы и т.д.
    }

    private void OnDestroy()
    {
        if (model != null)
            model.OnEngineStateChanged -= OnEngineStateChanged;
    }
}