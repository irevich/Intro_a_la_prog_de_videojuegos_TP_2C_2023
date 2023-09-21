using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool _isGameOver = false;
    [SerializeField] private bool _isVictory = false;
    [SerializeField] private Text _gameOverText;

    #region UNITY_EVENTS

    void Start()
    {
        EventsManager.instance.OnGameOver += OnGameOver;
        //_gameOverText.text = string.Empty;
    }
    
    
    #endregion

    #region ACTIONS

    private void OnGameOver(bool isVictory)
    {
        _isGameOver = true;
        _isVictory = isVictory;
        
        _gameOverText.text = _isVictory ? "You Win!" : "You Lose!";
        _gameOverText.color = _isVictory ? Color.green : Color.red;
    }
    

    #endregion
}
