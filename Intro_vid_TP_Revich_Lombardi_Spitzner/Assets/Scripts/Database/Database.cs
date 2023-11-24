using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;

public class Database
{
    private const string _dbName = "database.s3db";
    private const string TableRanking = "RankingRecords";
    private string _connPath;
    private IDbConnection _dbConn;

    public Database()
    {
        _connPath = $"URI=file:{Application.dataPath}/{_dbName}";
        _dbConn = new SqliteConnection(_connPath);
        
        //DropTableRankingRecords();
        CreateTableRankingRecords();
    }

    #region COMMON_ACTIONS
    private void PostQueryToDb(string query)
    {
        try
        {
            _dbConn.Open();
            IDbCommand command = _dbConn.CreateCommand();
            command.CommandText = query;
            command.ExecuteReader();

            command.Dispose();
            command = null;
        }
        catch (Exception e)
        {
            Debug.LogError($"POST QUERY ERROR: {e.Message}");
        }
        finally
        {
            _dbConn.Close();
        }
    }
    #endregion

    #region TABLE_RANKING_ACTIONS

    private void DropTableRankingRecords()
    {
        try {
            string query = $"DROP TABLE IF EXISTS {TableRanking}";
            this.PostQueryToDb(query);
        }
        catch (Exception)
        {
            Debug.LogWarning("There is no table to drop");
        }
    }

    private void CreateTableRankingRecords()
    {
        string query = 
            $"CREATE TABLE IF NOT EXISTS {TableRanking} ( " +
                "Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "level INTEGER NOT NULL, " +
                "won INTEGER NOT NULL, " +
                "timeRemaining FLOAT NOT NULL)";
        this.PostQueryToDb(query);
    }

    public void AddRankingRecord(RankingModel record)
    {
        string query = string.Format(
            $"INSERT INTO  {TableRanking}" +
                "(level, won, timeRemaining) " +
                "VALUES ({0},{1},{2})", 
                record.Level, record.Won ? 1 : 0, record.TimeRemaining);
        PostQueryToDb(query);
    }

    public List<RankingModel> GetAllRankingRecords()
    {
        var records = new List<RankingModel>();
        try
        {
            _dbConn.Open();

            IDbCommand command = _dbConn.CreateCommand();
            string sqlQuery = "SELECT level, won, timeRemaining FROM RankingRecords";
            command.CommandText = sqlQuery;

            IDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var record = new RankingModel(reader.GetInt32(0), 
                    reader.GetInt32(1) == 1, 
                    reader.GetFloat(2));
                records.Add(record);

                
            }

            reader.Close();
            reader = null;
            command.Dispose();
            command = null;
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
        finally
        {
            _dbConn.Close();
        }

        return records;
    }
    #endregion
}
