using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager instance;

    #region UNITY_EVENTS

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }

    #endregion

    #region GAME_MANAGER_ACTIONS

    public event Action<bool> OnGameOver;

    public void EventGameOver(bool isVictory)
    {
        if (OnGameOver != null)
            OnGameOver(isVictory);
    }

    #endregion

    #region STUDENT_SPOTTED_ACTIONS

    public event Action OnCharacterSpotted;
    public event Action OnStudentSpottedFromGoalDoor;

    public void EventCharacterSpotted()
    {
        if (OnCharacterSpotted != null)
        {
            OnCharacterSpotted();
        }
    }

    public void EventStudentSpottedFromGoalDoor()
    {
        if (OnStudentSpottedFromGoalDoor != null)
        {
            OnStudentSpottedFromGoalDoor();
        }
    }

    #endregion


    #region STUDENT_ACTIONS

    public event Action<int, int> OnStudentLifeDamage;

    public void EventStudentLifeDamage(int currentLife, int maxLife)
    {
        if (OnStudentLifeDamage != null)
            OnStudentLifeDamage(currentLife, maxLife);
    }

    #endregion
}