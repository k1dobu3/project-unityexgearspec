using UnityEngine;

[CreateAssetMenu(fileName = "Vehicle", menuName = "Scriptable Objects/Vehicle")]
public class Vehicle : ScriptableObject
{
    [Header("Engine config")]
    public float MaxVehicleSpeed;
    public bool IsEngineOn;

    [Header("Mass config")]
    public float VehicleMass;
}
