using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdEnemyMovement : ICommand
{
    private IEnemyMoveable _moveable;
    
    public CmdEnemyMovement(IEnemyMoveable moveable)
    {
        _moveable = moveable;
    }
    
    public void Do()
    {
        _moveable.MoveTowardsPlayer();
    }
}
