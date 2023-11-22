
using UnityEngine;
public class CharacterMovementController : MonoBehaviour, IMoveable
{
    public float MovementSpeed => GetComponent<Student>().StudentStats.MovementSpeed;
    public float TurnSpeed => GetComponent<Student>().StudentStats.RotateSpeed;

    public virtual void Move(Vector3 direction)
    {
        transform.Translate(direction * (MovementSpeed * Time.deltaTime));
    }

    public void Turn(Vector3 direction)
    {
        transform.Rotate(direction * (TurnSpeed * Time.deltaTime), Space.Self);
    }
}