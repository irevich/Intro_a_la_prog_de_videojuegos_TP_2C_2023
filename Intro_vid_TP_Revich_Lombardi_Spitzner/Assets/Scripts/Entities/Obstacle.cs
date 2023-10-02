
using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Obstacle : MonoBehaviour
{
    public Collider Collider => _collider;
    //public Rigidbody Rb => _rigidbody;
    
    private Collider _collider;
    //private Rigidbody _rigidbody;
    [SerializeField] private EnemyStats _enemyStats;
    
    #region UNITY_EVENTS

    private void Start()
    {
        _collider = GetComponent<Collider>();
        //_rigidbody = GetComponent<Rigidbody>();
        
        //_rigidbody.isKinematic = false;
        //_rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
    }

    #endregion

    #region COLLISION_EVENTS

    private void OnCollisionEnter(Collision other)
    {
        // TODO: capaz hacerlo con tags o layers como vimos en clase
        if (other.gameObject.name.Equals("Player"))
        {
            IDamageable toDamage = other.gameObject.GetComponent<IDamageable>();
            if (toDamage != null)
            {
                EventQueueManager.instance.AddEvent(new CmdAttack(_enemyStats.damage, 
                    toDamage));
                Debug.Log("Player hit!!");
            }
            
            // TODO: fijarse que este sea el evento indicado
            EventsManager.instance.StudentLifeDamage(
                other.gameObject.GetComponent<Actor>().Life, 
                other.gameObject.GetComponent<Actor>().MaxLife);

        }
    }

    #endregion
}