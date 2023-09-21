using UnityEngine;

public class CmdRotate : ICommand
{
    private Transform _transform;
    private Vector3 _direction;
    private float _speed;
    
    public CmdRotate(Transform transform, Vector3 direction, float speed)
    {
        _transform = transform;
        this._direction = direction;
        _speed = speed;
    }
    
    public void Do()
    {
        _transform.Rotate(_direction * (_speed * Time.deltaTime), Space.Self);
    }
}