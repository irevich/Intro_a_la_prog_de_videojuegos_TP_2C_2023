
using System;
using UnityEngine;

// Hace que le agregue esos componentes
[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    public Transform _target;
    public float _speed = 3f;
    
    public Collider Collider => _collider;
    public Rigidbody Rb => _rigidbody;
    
    private Collider _collider;
    private Rigidbody _rigidbody;
    
    #region UNITY_EVENTS

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
        
        _collider.isTrigger = true;
        _rigidbody.isKinematic = true;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
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
            transform.position = Vector3.MoveTowards(transform.position,newPos, _speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (_target)
        {
            MoveTowardsPlayer();
        }

        else
        {
            //TODO: movimiento random?
        }
    }

    #endregion

    #region TRIGGER_EVENTS
    // TODO: capaz hacerlo con tags
    private void OnTriggerEnter(Collider other)
    {
        // TODO: ojo con el nombre
        if (other.name.Equals("Player"))
        {
            //_target = other.transform;
            EventsManager.instance.EventCharacterSpotted();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.name.Equals("Player"))
            _target = null;
    }
    #endregion
}
