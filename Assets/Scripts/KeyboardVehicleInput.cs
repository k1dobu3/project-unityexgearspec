// KeyboardVehicleInput.cs
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardVehicleInput : IVehicleInput
{
    public float MoveInput { get; private set; }
    public float TurnInput { get; private set; }
    public bool EngineTogglePressed { get; private set; }

    private readonly Keyboard _keyboard;

    public KeyboardVehicleInput()
    {
        _keyboard = Keyboard.current;
    }

    public void Update()
    {
        if (_keyboard == null) return;

        float forward = _keyboard.wKey.isPressed ? 1f : 0f;
        float backward = _keyboard.sKey.isPressed ? 1f : 0f;
        MoveInput = forward - backward;

        float right = _keyboard.dKey.isPressed ? 1f : 0f;
        float left = _keyboard.aKey.isPressed ? 1f : 0f;
        TurnInput = right - left;

        EngineTogglePressed = _keyboard.eKey.wasPressedThisFrame;
    }
}