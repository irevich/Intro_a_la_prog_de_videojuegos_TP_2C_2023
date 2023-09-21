using UnityEngine;

public interface IMovable
{
    public float MovementSpeed { get; }
    public float RotationSpeed { get; }

    public void Move(Vector3 direction);
    public void Rotate(Vector3 direction);
}
