using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;


[RequireComponent(typeof(SphereCollider), typeof(CapsuleCollider), typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    public EnemyStats EnemyStats => _enemyStats;
    [SerializeField] private EnemyStats _enemyStats;
    public AbstractEnemyMovementController _enemyMovementController;

    #region COLLIDERS

    public SphereCollider SphereCollider => _sphereCollider;
    public Rigidbody Rb => _rigidbody;
    private SphereCollider _sphereCollider;
    private Rigidbody _rigidbody;

    #endregion

    #region UNITY_EVENTS

    protected void Start()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        _rigidbody = GetComponent<Rigidbody>();

        _sphereCollider.isTrigger = true;
        _sphereCollider.radius = _enemyStats.DetectionDistance;

        _rigidbody.isKinematic = true;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;   
        _enemyMovementController = GetComponent<AbstractEnemyMovementController>();
        InitMovementCommands();
    }

    #region MOVEMENT_CMD

    private CmdEnemyMovement _cmdMoveTowardsPlayer;
    private CmdEnemyUndetectedMove _cmdUndetectedMove;
    private void InitMovementCommands()
    {
        _cmdMoveTowardsPlayer = new CmdEnemyMovement(_enemyMovementController);
        _cmdUndetectedMove = new CmdEnemyUndetectedMove(_enemyMovementController);
    }
    #endregion


    private void FixedUpdate()
    {
        if (_enemyMovementController._target)
        {
            _cmdMoveTowardsPlayer.Do();
        }
        else
        {
            _cmdUndetectedMove.Do();
        }
    }

    #endregion

    #region TRIGGER_EVENTS

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals(Enums.Tags.Player.ToString()))
        {
            _enemyMovementController._target = other.transform;
            EventsManager.instance.EventCharacterSpotted();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals(Enums.Tags.Player.ToString())) 
        {
            _enemyMovementController._target = null;
        }
            
    }

    #endregion

    #region COLLIDER_EVENTS

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals(Enums.Tags.Player.ToString()))
        {
            IDamageable toDamage = other.gameObject.GetComponent<IDamageable>();
            if (toDamage != null)
            {
                EventQueueManager.instance.AddEvent(new CmdAttack(_enemyStats.damage,
                    toDamage));

                EventsManager.instance.EventStudentLifeDamage(
                    other.gameObject.GetComponent<Actor>().Life,
                    other.gameObject.GetComponent<Actor>().MaxLife);
            }
        }
    }

    #endregion
}