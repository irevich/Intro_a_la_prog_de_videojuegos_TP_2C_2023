using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiElementsManager : MonoBehaviour
{
    #region LIFE_BAR_LOGIC

    [SerializeField] private Image _lifebar;
    [SerializeField] private Text _lifePercentage;

    private float yellowLifePercentageLimit = .5f;
    private float redLifePercentageLimit = .1f;

    #endregion

    #region TIMER_LOGIC

    [SerializeField] private Text _timerTime;
    [SerializeField] private float _remainingTime;

    private int secondsLimit = 10;

    private void updateTimer()
    {
        int minutes = Mathf.FloorToInt(_remainingTime / 60);
        int seconds = Mathf.FloorToInt(_remainingTime % 60);
        //Set timer text
        _timerTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        //Set timer color
        if (minutes == 0 && seconds <= secondsLimit)
        {
            _timerTime.color = Color.red;
        }
    }

    #endregion

    #region SUBSCRIBED_EVENTS

    private void OnStudentLifeDamage(int currentLife, int maxLife)
    {
        if (currentLife >= 0)
        {
            float lifePercentage = (float)currentLife / (float)maxLife;
            _lifebar.fillAmount = lifePercentage;
            _lifePercentage.text = $"{lifePercentage * 100} %";

            _lifePercentage.color = lifePercentage <= redLifePercentageLimit ? Color.red :
                lifePercentage <= yellowLifePercentageLimit ? Color.yellow :
                Color.green;
        }
    }

    #endregion

    #region Unity_Events

    void Start()
    {
        EventsManager.instance.OnStudentLifeDamage += OnStudentLifeDamage;
        updateTimer();
    }

    private void Update()
    {
        //Check timer to see if the player lost, and update it
        if (_remainingTime > 0)
        {
            _remainingTime -= Time.deltaTime;
            updateTimer();
        }
        else
        {
            _remainingTime = 0;
            //If time's out, player has lost
            EventsManager.instance.EventGameOver(false);
        }
    }

    #endregion
}