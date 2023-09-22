using UnityEngine;

public class CmdMovement : ICommand
{
    private Transform _transform;
    private Vector3 _direction;
    private float _speed;
    
    public CmdMovement(Transform transform, Vector3 direction, float speed)
    {
        _transform = transform;
        _direction = direction;
        _speed = speed;
    }
    
    public void Do()
    {
        Debug.Log("Doing Move");
        _transform.Translate(_direction * (_speed * Time.deltaTime));
    }
}