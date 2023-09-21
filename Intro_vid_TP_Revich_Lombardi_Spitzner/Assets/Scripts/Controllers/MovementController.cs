
using UnityEngine;

public class MovementController : IMovable
{
    public float MovementSpeed { get; }
    public float RotationSpeed { get; }
    public void Move(Vector3 direction)
    {
        throw new System.NotImplementedException();
    }

    public void Rotate(Vector3 direction)
    {
        throw new System.NotImplementedException();
    }
}