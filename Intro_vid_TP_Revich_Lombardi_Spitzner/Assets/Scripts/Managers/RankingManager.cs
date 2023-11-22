using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    [SerializeField] private Transform _parentGrid;
    [SerializeField] private GameObject _rankingElementPrefab;
    
    private List<RankingModel> _players = new List<RankingModel>();
    
    private Database _database;

    private void Start()
    {
        _database = new Database();
        
        _players = _database.GetAllRankingRecords();
        foreach (RankingModel player in _players)
        {
            RankingUIElement element = Instantiate(_rankingElementPrefab, _parentGrid).GetComponent<RankingUIElement>();
            element.Init(player.Level, player.Won, player.TimeRemaining);
        }
    }
}
