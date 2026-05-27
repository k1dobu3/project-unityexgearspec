using UnityEngine;
using UnityEngine.InputSystem;

// IVehicleInput.cs
public interface IVehicleInput
{
    float MoveInput { get; }
    float TurnInput { get; }
    bool EngineTogglePressed { get; }   // для кнопки включения двигателя
    public void Update();
}
