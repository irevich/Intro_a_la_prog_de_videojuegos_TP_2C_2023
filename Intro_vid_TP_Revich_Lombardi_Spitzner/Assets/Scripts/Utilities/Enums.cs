
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
        Level1,
        Victory,
        Defeat
    }
    public enum Tags
    {
        Player
    }
}
