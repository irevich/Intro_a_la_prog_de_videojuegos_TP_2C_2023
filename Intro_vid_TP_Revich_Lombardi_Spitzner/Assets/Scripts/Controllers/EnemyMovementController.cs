using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class EnemyMovementController : AbstractEnemyMovementController
{
    // public float MovementSpeed => GetComponent<Enemy>().EnemyStats.MovementSpeed;

    // private Animator _animator => GetComponent<Animator>();
    // private Transform _target;


    private Vector3 RandomVector(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = 0;
        var z = 0;
        return new Vector3(x, y, z);
    }
    public override void UndetectedMove()
    {
        Vector3 newPos = transform.position + RandomVector(-5, 5);
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