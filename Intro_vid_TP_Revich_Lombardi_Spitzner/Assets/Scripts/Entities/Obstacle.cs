
using System;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class Obstacle : MonoBehaviour
{
    public Collider Collider => _collider;
    public Rigidbody Rb => _rigidbody;
    
    private Collider _collider;
    private Rigidbody _rigidbody;
    
    #region UNITY_EVENTS

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
        
        _rigidbody.isKinematic = false;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
    }

    #endregion

    #region COLLISION_EVENTS

    private void OnCollisionEnter(Collision other)
    {
        // TODO: capaz hacerlo con tags o layers como vimos en clase
        if (other.gameObject.name.Equals("Player"))
        {
            // Lastimarlo
            Debug.Log("Player hit!!");
        }
    }

    #endregion
}