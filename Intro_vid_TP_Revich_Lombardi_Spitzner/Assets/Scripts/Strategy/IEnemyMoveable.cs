using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyMoveable
{
    float MovementSpeed {get;}

    void UndetectedMove();
    void MoveTowardsPlayer();
}
