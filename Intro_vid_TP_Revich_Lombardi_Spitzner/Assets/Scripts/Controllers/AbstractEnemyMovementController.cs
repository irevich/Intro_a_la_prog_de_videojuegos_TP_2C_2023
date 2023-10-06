using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEnemyMovementController : MonoBehaviour, IEnemyMoveable
{
    public float MovementSpeed => GetComponent<Enemy>().EnemyStats.MovementSpeed;
    protected Animator _animator => GetComponent<Animator>();
    public Transform _target;
    abstract public void UndetectedMove();
    abstract public void MoveTowardsPlayer();
}
