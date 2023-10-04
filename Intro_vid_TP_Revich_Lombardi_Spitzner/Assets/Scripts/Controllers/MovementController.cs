
using UnityEngine;

public class MovementController : IMoveable
{
    public float MovementSpeed { get; }
    public float TurnSpeed { get; }
    public void Move(Vector3 direction)
    {
        throw new System.NotImplementedException();
    }

    public void Turn(Vector3 direction)
    {
        throw new System.NotImplementedException();
    }
}