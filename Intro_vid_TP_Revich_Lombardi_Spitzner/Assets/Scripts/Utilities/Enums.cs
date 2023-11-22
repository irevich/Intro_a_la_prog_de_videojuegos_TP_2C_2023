
using System;
using UnityEngine;

public class Enums : MonoBehaviour
{
    #region SINGLETON
    public Enums instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    #endregion

    public enum Levels
    {
        MainMenu,
        LoadScreen,
        Intro,
        Level1,
        Level2,
        Victory,
        Defeat,
        Ranking
    }
    public enum Tags
    {
        Player
    }
}
