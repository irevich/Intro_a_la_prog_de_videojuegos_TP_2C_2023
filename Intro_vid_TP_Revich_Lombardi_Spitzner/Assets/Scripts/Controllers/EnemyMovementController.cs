using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class EnemyMovementController : AbstractEnemyMovementController
{
    // public float MovementSpeed => GetComponent<Enemy>().EnemyStats.MovementSpeed;

    // private Animator _animator => GetComponent<Animator>();
    // private Transform _target;

    [SerializeField] private float _maxDistance = 3f;
    public Vector3 _currentDirection = new Vector3(1,0,0);
    private bool hasToTurn = false;
    private bool isInitPositionDefined = false;
    private float initXPosition;
    private Vector3 RandomVector(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = 0;
        var z = 0;
        return new Vector3(x, y, z);
    }
    public override void UndetectedMove()
    {
        if (!isInitPositionDefined)
        {
            isInitPositionDefined = true;
            initXPosition = transform.position.x;
        }
            
        Vector3 newPos = transform.position + _currentDirection;
        if (Mathf.Abs(transform.position.x - initXPosition)  >  _maxDistance)
        {
            if (!hasToTurn)
            {
                _currentDirection.x = -_currentDirection.x;
                hasToTurn = true;
            }    
        }
        else
        {
            if (hasToTurn)
                hasToTurn = false;
        }
        if (newPos.x > transform.position.x)
        {
            _animator.Play("Move Right");
        }
        else if (newPos.x < transform.position.x)
        {
            _animator.Play("Move Left");
        }

        transform.position = Vector3.MoveTowards(transform.position, newPos, MovementSpeed * Time.deltaTime);
    }

    public override void MoveTowardsPlayer()
    {
        Vector3 newPos = transform.position;
        newPos.x = _target.position.x;
        
        if (_target.position.x > transform.position.x)
        {
            _animator.Play("Move Right");
        }
        else if (_target.position.x < transform.position.x)
        {
            _animator.Play("Move Left");
        }

        transform.position = Vector3.MoveTowards(transform.position, newPos, MovementSpeed * Time.deltaTime);
    }

    
}