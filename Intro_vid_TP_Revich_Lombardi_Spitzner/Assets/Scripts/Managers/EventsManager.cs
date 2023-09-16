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
            Destroy(this); // Asegurarse de que tenga lo mas basico
        instance = this;
    }

    #endregion

    #region GAME_MANAGER_ACTIONS

    public event Action<bool> OnGameOver; // Action en si
    
    // Disparador del action
    public void EventGameOver(bool isVictory)
    {
        if (OnGameOver != null)
            OnGameOver(isVictory);
    }

    #endregion
}
