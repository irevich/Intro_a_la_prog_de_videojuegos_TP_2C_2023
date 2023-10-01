
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

    public enum Tags
    {
        Player
    }
}
