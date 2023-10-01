using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityStats", menuName = "Stats/StudentStats", order = 0)]
public class StudentStats : EntityStats
{
    [SerializeField] private StudentStatsValues studentStats;
    //public float MovementSpeed => studentStats.MovementSpeed;
    public float RotateSpeed => studentStats.RotateSpeed;
}

[System.Serializable]
public struct StudentStatsValues
{
    //public float MovementSpeed;
    public float RotateSpeed;
}
