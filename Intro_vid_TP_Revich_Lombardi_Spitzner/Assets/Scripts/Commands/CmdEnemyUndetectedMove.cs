using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdEnemyUndetectedMove : ICommand
{
    private IEnemyMoveable _moveable;
    
    public CmdEnemyUndetectedMove(IEnemyMoveable moveable)
    {
        _moveable = moveable;
    }
    
    public void Do()
    {
        _moveable.UndetectedMove();
    }
}
