
using System;
using UnityEngine;
using System.Collections;
using Random=UnityEngine.Random;


// Hace que le agregue esos componentes
[RequireComponent(typeof(SphereCollider), typeof(CapsuleCollider), typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    public Transform _target;
    public float _speed = 3f;
    public float _detectionDistance = 15.0f;


    public SphereCollider SphereCollider => _sphereCollider;
    
    public CapsuleCollider CapsuleCollider => _capsuleCollider;
    public Rigidbody Rb => _rigidbody;
    
    private SphereCollider _sphereCollider;
    private CapsuleCollider _capsuleCollider;
    private Rigidbody _rigidbody;
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
            } else if (_target.position.x < transform.position.x)
            {
                _animator.Play("Move Left");
            }
            transform.position = Vector3.MoveTowards(transform.position,newPos, _speed * Time.deltaTime);
    }

    private Vector3 RandomVector(float min, float max) {
		var x = Random.Range(min, max);
		var y = 0;
		var z = 0;
		return new Vector3(x, y, z);
	}

    // private void MoveInCircles()
    // {
    //     float x = _center.x + _radius * Mathf.Cos(_angle);
    //     float z = _center.z + _radius * Mathf.Sin(_angle);

    //     // Set the new position
    //     //transform.position = new Vector3(x, transform.position.y, z);
    //     transform.position = Vector3.MoveTowards(transform.position,new Vector3(x, transform.position.y, z), _circularSpeed * Time.deltaTime);

    //     // Update the angle for the next frame
    //     _angle += _circularSpeed * Time.deltaTime;

    //     // Ensure the angle stays within a full circle
    //     if (_angle >= 360.0f)
    //         _angle -= 360.0f;
    // }


    protected virtual void UndetectedMove()
    {
        Vector3 newPos = transform.position+RandomVector(-5,5);
        if (newPos.x > transform.position.x)
            {
                _animator.Play("Move Right");
            } else if (newPos.x < transform.position.x)
            {
                _animator.Play("Move Left");
            }
        transform.position = Vector3.MoveTowards(transform.position,newPos, _speed * Time.deltaTime);
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
                EventQueueManager.instance.AddEvent(new CmdAttack(1, toDamage));
                
                // TODO: fijarse que este sea el evento indicado
                EventsManager.instance.StudentLifeDamage(
                    other.gameObject.GetComponent<Actor>().Life, 
                    other.gameObject.GetComponent<Actor>().MaxLife);
                Debug.Log("Player hit!!");
            }
        }
    }

    #endregion
}
