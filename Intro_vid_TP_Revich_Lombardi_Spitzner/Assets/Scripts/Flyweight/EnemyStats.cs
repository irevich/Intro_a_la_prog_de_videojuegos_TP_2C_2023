using UnityEngine;

[CreateAssetMenu(fileName = "EntityStats", menuName = "Stats/EnemyStats", order = 0)]
public class EnemyStats : EntityStats
{
    [SerializeField] private DamageStatsValues _enemyStats;
    public int damage => _enemyStats.damage;
    // public float MovementSpeed => _enemyStats.speed;
    public float DetectionDistance => _enemyStats.detectionDistance;
}

[System.Serializable]
public struct DamageStatsValues
{
    public int damage;
    // public float speed;
    public float detectionDistance;
}