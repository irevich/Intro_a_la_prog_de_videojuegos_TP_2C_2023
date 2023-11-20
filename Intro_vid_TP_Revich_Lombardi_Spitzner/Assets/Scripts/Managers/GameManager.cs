using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool _isGameOver = false;
    [SerializeField] private bool _isVictory = false;
    [SerializeField] private Text _gameOverText;

    //Variable to manage current level
    private static int currentLevel = 0;

    #region UNITY_EVENTS

    void Start()
    {
        EventsManager.instance.OnGameOver += OnGameOver;
    }

    #endregion

    #region ACTIONS

    private void OnGameOver(bool isVictory)
    {
        _isGameOver = true;
        _isVictory = isVictory;

        //Change current level
        currentLevel = _isVictory ? currentLevel + 1 : 1;

        LoadCreditsScreen();
    }


    private void LoadCreditsScreen()
    {
        SceneManager.LoadScene(_isGameOver && _isVictory ? (int)Enums.Levels.Victory : (int)Enums.Levels.Defeat);
    }

    public static int getCurrentLevel(){
        return currentLevel;
    }

    public static void resetCurrentLevel(){
        currentLevel = 0;
    }

    public static void incrementCurrentLevel(){
        currentLevel++;
    }

    #endregion
}