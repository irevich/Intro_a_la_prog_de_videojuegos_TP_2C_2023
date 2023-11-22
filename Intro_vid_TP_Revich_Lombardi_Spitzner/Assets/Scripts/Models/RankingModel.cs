using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingModel
{
    public int Level => _level;
    public bool Won => _won;
    public float TimeRemaining => _timeRemaining;

    private int _level;
    private bool _won;
    private float _timeRemaining;

    public RankingModel(int level, bool won, float timeRemaining)
    {
        this._level = level;
        this._won = won;
        this._timeRemaining = timeRemaining;
    }
    
    public override string ToString()
    {
        return string.Format("level: {0} \t won: {1} \t timeRemaining: {2}", _level, _won, _timeRemaining);
    }
}
