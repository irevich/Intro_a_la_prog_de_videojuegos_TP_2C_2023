using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class GoalDoor : MonoBehaviour
{
    public Collider Collider => _collider;
    private Collider _collider;

    #region UNITY_EVENTS

    

    
    void Start()
    {
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
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
}
