using UnityEngine;

[CreateAssetMenu(fileName = "EntityStats", menuName = "Stats/EnemyStats", order = 0)]
public class EnemyStats : ScriptableObject
{
    [SerializeField] private DamageStatsValues _enemyStats;
    public int damage => _enemyStats.damage;
}

[System.Serializable]
public struct DamageStatsValues
{
    public int damage;
}