using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class ProfessorMovementController : AbstractEnemyMovementController
{
    // public float MovementSpeed => GetComponent<FollowingEnemy>().EnemyStats.MovementSpeed;
    // private Animator _animator => GetComponent<Animator>();
    // private Transform _target;

    public float _circularSpeed = 1.0f;   // Speed of movement
    public float _radius = 12.0f;  // Radius of the circle
    public Vector3 _center => transform.position;  // Center of the circle

    private float _angle = 0; 

    private void MoveInCircles()
    {
        float x = _center.x + _radius * Mathf.Cos(_angle);
        float z = _center.z + _radius * Mathf.Sin(_angle);

        // Set the new position
        //transform.position = new Vector3(x, transform.position.y, z);
        transform.position = Vector3.MoveTowards(transform.position,new Vector3(x, transform.position.y, z), _circularSpeed * Time.deltaTime);

        // Update the angle for the next frame
        _angle += _circularSpeed * Time.deltaTime;

        // Ensure the angle stays within a full circle
        if (_angle >= 360.0f)
            _angle -= 360.0f;

      Vector3 lookPos = new Vector3(x, transform.position.y, z);
      lookPos.y = transform.position.y;
      transform.LookAt(lookPos);
    }

    public override void UndetectedMove()
    {
        MoveInCircles();
    }

    public override void MoveTowardsPlayer()
    {
        Vector3 lookPos = _target.position;
        lookPos.y = transform.position.y;
        transform.position = Vector3.MoveTowards(transform.position, 
                    _target.position, MovementSpeed * Time.deltaTime);
        transform.LookAt(lookPos);
    }
}
