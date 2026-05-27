using UnityEngine;

public class VehicleModel
{
    public event System.Action<bool> OnEngineStateChanged;

    private bool _isEngineOn;
    public bool IsEngineOn
    {
        get => _isEngineOn;
        private set
        {
            if (_isEngineOn != value)
            {
                _isEngineOn = value;
                OnEngineStateChanged?.Invoke(_isEngineOn);
            }
        }
    }

    public float CurrentSpeed { get; private set; } // можно расширить позже

    public VehicleModel(Vehicle settings)
    {
        IsEngineOn = settings.IsEngineOnByDefault;
    }

    public void ToggleEngine() => IsEngineOn = !IsEngineOn;

    // Можно добавить методы: Accelerate, Brake и т.д.
}
