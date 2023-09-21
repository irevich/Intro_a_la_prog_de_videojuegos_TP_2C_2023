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
        print("En awake del events manager");
        if (instance != null)
            Destroy(this); // Asegurarse de que tenga lo mas basico
        instance = this;
    }
    #endregion

    #region GAME_MANAGER_ACTIONS

    public event Action<bool> OnGameOver; // Action en si
    
    // TODO: action cuando el profesor detecta al alumno -> musica + logo?
    public event Action OnCharacterSpotted;
    
    public event Action<float, float> OnCharacterHealthChanged;
    
    // Disparador del action
    public void EventGameOver(bool isVictory)
    {
        if (OnGameOver != null)
            OnGameOver(isVictory);
    }
    
    public void EventCharacterSpotted()
    {
        if (OnCharacterSpotted != null)
        {
            OnCharacterSpotted();
            Debug.Log("Character Spotted");
        }
    }
    
    public void EventCharacterHealthChanged(float currentHealth, float maxHealth)
    {
        if (OnCharacterHealthChanged != null)
            OnCharacterHealthChanged(currentHealth, maxHealth);
    }

    #endregion

    #region STUDENT_ACTIONS
    public event Action<int, int> OnStudentLifeDamage;

    public void StudentLifeDamage(int currentLife, int maxLife){

        if (OnStudentLifeDamage != null)
            OnStudentLifeDamage(currentLife,maxLife);

    }

    #endregion
}
