using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class WaterPuddle : MonoBehaviour
{
    public Collider Collider => _collider;
    private Collider _collider;
    private bool _studentDetected = false;

    [SerializeField] private float _waterEffectTime;
    private float _remainingWaterEffectTime;

    #region UNITY_EVENTS

    void Start()
    {
        _remainingWaterEffectTime = _waterEffectTime;
        _studentDetected = false;
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
    }

    void Update()
    {
        //Check if the student was detected, and in that case, if the water effect time has finished
        if (_studentDetected){

            if (_remainingWaterEffectTime > 0)
            {
                _remainingWaterEffectTime -= Time.deltaTime;
            }
            else{
                //If time's out, restore parameters to normal values, and student to his normal movement controller             
                _studentDetected = false;
                _remainingWaterEffectTime = _waterEffectTime;
                EventsManager.instance.EventStudentWaterPuddleRecovered();
            }
        }
    }

    #endregion

    #region TRIGGER_ACTIONS

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals(Enums.Tags.Player.ToString()))
        {
            _studentDetected = true;
            EventsManager.instance.EventStudentWaterPuddleEntered();
        }
    }

    #endregion
}
