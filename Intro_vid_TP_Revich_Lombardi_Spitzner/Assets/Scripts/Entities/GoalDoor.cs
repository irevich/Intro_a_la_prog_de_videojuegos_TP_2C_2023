using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class GoalDoor : MonoBehaviour
{
    public Collider Collider => _collider;
    private Collider _collider;
    private bool _studentDetected = false;

    [SerializeField] private float _raycastRange = 15f;


    #region UNITY_EVENTS


    void Start()
    {
        _studentDetected = false;
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
    }

    private void Update()
    {
        //Save all collisions detected info
        RaycastHit hitInfo;

        //Basic info of the ray to shoot
        Vector3 raycastDirection = getRaycastDirection();
        Ray ray = new Ray(transform.position, raycastDirection);
        // Debug.DrawRay(transform.position, raycastDirection * _raycastRange, Color.red);

        //Check for collisions if the student hasn't been detected yet
        if (!_studentDetected && Physics.Raycast(ray, out hitInfo, _raycastRange)){

            //If is the player, send the corresponding event for the Sound Manager to reproduce a near by sound
            if (hitInfo.collider.tag.Equals(Enums.Tags.Player.ToString())){
                _studentDetected = true;
                EventsManager.instance.EventStudentSpottedFromGoalDoor();
            }
        }

    }

    #endregion

    #region TRIGGER_ACTIONS

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals(Enums.Tags.Player.ToString()))
        {
            EventsManager.instance.EventGameOver(true);
        }
    }

    #endregion

    #region GOAL_DOOR_METHODS

    private Vector3 getRaycastDirection()
    {
        Vector3 raycastDirection;
        switch (GameManager.getCurrentLevel()){

            case 1:
                raycastDirection = Vector3.forward;
                break;
            case 2:
                raycastDirection = -Vector3.right;
                break;
            default:
                raycastDirection = Vector3.forward;
                break;
        }
        return raycastDirection;
    }

    #endregion
}
