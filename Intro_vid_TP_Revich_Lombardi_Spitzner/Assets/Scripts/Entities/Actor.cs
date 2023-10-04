using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour, IDamageable
{

    #region IDAMAGEABLE_PROPERTIES
    public int MaxLife => _entityStats.MaxLife;

    public int Life => _life;

    #endregion

    #region PRIVATE_PROPERTIES
    
    public EntityStats Stats => _entityStats;
    private int _life;
    [SerializeField] protected EntityStats _entityStats;

    #endregion

    #region UNITY_EVENTS
    protected void Start()
    {
        _life = MaxLife;
        EventsManager.instance.EventStudentLifeDamage(Life, MaxLife);
    }
    #endregion

    #region IDAMAGEABLE_METHODS

    public void TakeDamage(int damage)
    {
        _life -= damage;
        print($"Life : {Life}");
        print($"MaxLife : {MaxLife}");
        print($"instance : {EventsManager.instance}");
        EventsManager.instance.EventStudentLifeDamage(Life, MaxLife);
        Debug.Log($"{name} Hit -> Life: {_life}!");

        if (_life <= 0) Die();
    }

    public void Die()
    {
        Debug.Log($"{name} Died!!!!!!");

        if (name.Equals(Enums.Tags.Player.ToString())) EventsManager.instance.EventGameOver(false);
        else Destroy(gameObject);
    }

    #endregion

}
