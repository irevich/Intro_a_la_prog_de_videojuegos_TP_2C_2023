using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour, IDamageable
{

    #region IDAMAGEABLE_PROPERTIES
    public int MaxLife => _maxLife;

    public int Life => _life;

    #endregion

    #region PRIVATE_PROPERTIES

    [SerializeField] private int _life; //currentLife
    [SerializeField] private int _maxLife;

    #endregion

    #region UNITY_EVENTS

    protected void Start()
    {
        _maxLife = 100;
        _life = MaxLife;
        //EventsManager.instance.StudentLifeDamage(Life, MaxLife);
    }


    #endregion

    #region IDAMAGEABLE_METHODS

    public void TakeDamage(int damage)
    {
        _life -= damage;
        print($"Life : {Life}");
        print($"MaxLife : {MaxLife}");
        print($"instance : {EventsManager.instance}");
        EventsManager.instance.StudentLifeDamage(Life, MaxLife);
        Debug.Log($"{name} Hit -> Life: {_life}!");

        if (_life <= 0) Die();
    }

    public void Die()
    {
        Debug.Log($"{name} Died!!!!!!");

        if (name.Equals("Character")) EventsManager.instance.EventGameOver(false);
        else Destroy(gameObject);
    }

    #endregion

}
