using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;


[RequireComponent(typeof(SphereCollider), typeof(CapsuleCollider), typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    public Transform _target;
    public float _speed = 3f;
    

    [SerializeField] protected EnemyStats _enemyStats;

    #region COLLIDERS

    public SphereCollider SphereCollider => _sphereCollider;
    public CapsuleCollider CapsuleCollider => _capsuleCollider;
    public Rigidbody Rb => _rigidbody;
    private SphereCollider _sphereCollider;
    private CapsuleCollider _capsuleCollider;
    private Rigidbody _rigidbody;

    #endregion

    private Animator _animator;

    #region UNITY_EVENTS

    protected void Start()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        _rigidbody = GetComponent<Rigidbody>();

        _sphereCollider.isTrigger = true;
        _sphereCollider.radius = 20f; // TODO: move to stats 

        _capsuleCollider = GetComponent<CapsuleCollider>();
        _capsuleCollider.isTrigger = false;

        _rigidbody.isKinematic = true;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        _animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
    }

    protected virtual void MoveTowardsPlayer()
    {
        Vector3 newPos = transform.position;
        newPos.x = _target.position.x;
        // TODO: speed and IMovable
        // transform.position = Vector3.MoveTowards(transform.position, 
        //     _target.position, _speed * Time.deltaTime);
        if (_target.position.x > transform.position.x)
        {
            _animator.Play("Move Right");
        }
        else if (_target.position.x < transform.position.x)
        {
            _animator.Play("Move Left");
        }

        transform.position = Vector3.MoveTowards(transform.position, newPos, _speed * Time.deltaTime);
    }

    private Vector3 RandomVector(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = 0;
        var z = 0;
        return new Vector3(x, y, z);
    }

    protected virtual void UndetectedMove()
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

        transform.position = Vector3.MoveTowards(transform.position, newPos, _speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (_target)
        {
            //if (Vector3.Distance(transform.position,_target.position) <= _detectionDistance) MoveTowardsPlayer();
            MoveTowardsPlayer();
        }
        else
        {
            UndetectedMove();
        }
    }

    #endregion

    #region TRIGGER_EVENTS

    private void OnTriggerEnter(Collider other)
    {
        // TODO: ojo con el nombre
        if (other.tag.Equals(Enums.Tags.Player.ToString()))
        {
            _target = other.transform;
            EventsManager.instance.EventCharacterSpotted();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals(Enums.Tags.Player.ToString()))
            _target = null;
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

                // TODO: fijarse que este sea el evento indicado
                EventsManager.instance.EventStudentLifeDamage(
                    other.gameObject.GetComponent<Actor>().Life,
                    other.gameObject.GetComponent<Actor>().MaxLife);
                Debug.Log("Player hit!!");
            }
        }
    }

    #endregion
}