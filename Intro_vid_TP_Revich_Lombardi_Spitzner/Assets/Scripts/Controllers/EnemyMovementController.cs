using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class EnemyMovementController : AbstractEnemyMovementController
{
    [SerializeField] private float _maxDistance = 3f;
    public Vector3 _currentDirection = new Vector3(1,0,0);
    private bool hasToTurn = false;
    private bool isInitPositionDefined = false;
    private float initXPosition;

    public enum AxisType
    {
        X,
        Z
    }

    public AxisType axisToToggle = AxisType.X;
    private Vector3 RandomVector(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = 0;
        var z = Random.Range(min, max);
        return new Vector3(x, y, z);
    }


    private void UndetectedMoveZ()
    {
        if (!isInitPositionDefined)
        {
            isInitPositionDefined = true;
            initXPosition = transform.position.z;
            _currentDirection = new Vector3(0,0,1);
        }
        
        Vector3 newPos = transform.position + _currentDirection;
        
        if (Mathf.Abs(transform.position.z - initXPosition)  >  _maxDistance)
        {
            if (!hasToTurn)
            {
                _currentDirection.z = -_currentDirection.z;
                hasToTurn = true;
            }    
        }
        else
        {
            if (hasToTurn)
                hasToTurn = false;
        }
        if (newPos.z > transform.position.z)
        {
            _animator.Play("Move Right");
        }
        else if (newPos.z < transform.position.z)
        {
            _animator.Play("Move Left");
        }

        transform.position = Vector3.MoveTowards(transform.position, newPos, MovementSpeed * Time.deltaTime);
    }

    private void UndetectedMoveX()
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

    public override void UndetectedMove()
    {
        
        switch (axisToToggle)
        {
            case AxisType.X:
                UndetectedMoveX();
                break;
            case AxisType.Z:
                UndetectedMoveZ();
                break;
        }
    }

    

    private void MoveTowardsPlayerXAxis()
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

    private void MoveTowardsPlayerZAxis()
    {
        Vector3 newPos = transform.position;
        newPos.z = _target.position.z;
        
        if (_target.position.z > transform.position.z)
        {
            _animator.Play("Move Right");
        }
        else if (_target.position.z < transform.position.z)
        {
            _animator.Play("Move Left");
        }

        transform.position = Vector3.MoveTowards(transform.position, newPos, MovementSpeed * Time.deltaTime);
    }

    public override void MoveTowardsPlayer()
    {
        
        switch (axisToToggle)
        {
            case AxisType.X:
                MoveTowardsPlayerXAxis();
                break;
            case AxisType.Z:
                MoveTowardsPlayerZAxis();
                break;
        }
    }

    
}