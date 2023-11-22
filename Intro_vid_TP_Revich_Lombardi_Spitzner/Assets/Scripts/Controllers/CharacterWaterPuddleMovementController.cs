using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWaterPuddleMovementController : CharacterMovementController
{
    public float WaterPuddleMovementSpeed => GetComponent<Student>().StudentStats.WaterPuddleMovementSpeed;

    public override void Move(Vector3 direction)
    {
        transform.Translate(direction * (WaterPuddleMovementSpeed * Time.deltaTime));
    }
}
