using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingUIElement : MonoBehaviour
{
    [SerializeField] private Text _level;
    [SerializeField] private Text _won;
    [SerializeField] private Text _timeRemaining;
    
    public void Init(int level, bool won, float timeRemaining)
    {
        _level.text = level.ToString();
        _won.text = won ? "Won" : "Lost";
        
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        //Set timer text
        _timeRemaining.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
