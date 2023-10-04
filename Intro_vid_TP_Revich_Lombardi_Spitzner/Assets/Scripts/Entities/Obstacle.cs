using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Obstacle : MonoBehaviour
{
    public Collider Collider => _collider;
    private Collider _collider;
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
        if (other.gameObject.tag.Equals(Enums.Tags.Player.ToString()))
        {
            IDamageable toDamage = other.gameObject.GetComponent<IDamageable>();
            if (toDamage != null)
            {
                EventQueueManager.instance.AddEvent(new CmdAttack(_enemyStats.damage,
                    toDamage));
                Debug.Log("Player hit!!");
            }

            // TODO: fijarse que este sea el evento indicado
            EventsManager.instance.EventStudentLifeDamage(
                other.gameObject.GetComponent<Actor>().Life,
                other.gameObject.GetComponent<Actor>().MaxLife);
        }
    }

    #endregion
}