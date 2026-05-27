using UnityEngine;

[CreateAssetMenu(fileName = "Vehicle/Settings", menuName = "Scriptable Objects/Vehicle")]
public class Vehicle : ScriptableObject
{
    [Header("Engine config")]
    public float MaxVehicleSpeed;
    public bool IsEngineOnByDefault;
    public float TurnSpeed = 120f;

    [Header("Mass config")]
    public float VehicleMass;
}