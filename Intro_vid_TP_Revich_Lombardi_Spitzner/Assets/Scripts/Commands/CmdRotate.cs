using UnityEngine;

public class CmdRotate : ICommand
{
    private IMoveable _moveable;
    private Vector3 _direction;
    
    public CmdRotate(IMoveable moveable, Vector3 direction)
    {
        _moveable = moveable;
        _direction = direction;
    }
    
    public void Do()
    {
        _moveable.Turn(_direction);
    }
}