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
    private static int maxLevel = 2;
    private Database _database;

    #region UNITY_EVENTS

    void Start()
    {
        EventsManager.instance.OnGameOver += OnGameOver;
        _database = new Database();
    }

    #endregion

    #region ACTIONS

    private void OnGameOver(bool isVictory)
    {
        _isGameOver = true;
        _isVictory = isVictory;

        if (!_isVictory || currentLevel == maxLevel)
        {
            // get remaining time from ui elements manager;
            GameObject uiElementsManagerObject = GameObject.Find("Managers");
            UiElementsManager uiElementsManager = uiElementsManagerObject.GetComponent<UiElementsManager>();
            float remainingTime = uiElementsManager.RemainingTime;
            _database.AddRankingRecord(new RankingModel(currentLevel, _isVictory, remainingTime)); //UiElementsManager.RemainingTime));
        }
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