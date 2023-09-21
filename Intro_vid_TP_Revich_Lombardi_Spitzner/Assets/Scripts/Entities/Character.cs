using UnityEngine;

public class Character : MonoBehaviour
{

    [SerializeField] private CharacterStats _characterStats;

    #region KEY_BINDINGS
    [SerializeField] private KeyCode _moveForward = KeyCode.W;
    [SerializeField] private KeyCode _moveBackward = KeyCode.S;
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;
    #endregion
    
    void Start()
    {
        InitMovementCommands();
    }

    #region UNITY_EVENTS
    void Update()
    {
        
    }
    #endregion

    private void FixedUpdate()
    {
        if (Input.GetKey(_moveForward))
            EventQueueManager.instance.AddEvent(_cmdMoveForward);
        
        if (Input.GetKey(_moveBackward))
            EventQueueManager.instance.AddEvent(_cmdMoveBack);
        
        if (Input.GetKey(_moveLeft))
            EventQueueManager.instance.AddEvent(_cmdRotateLeft);
        
        if (Input.GetKey(_moveRight))
            EventQueueManager.instance.AddEvent(_cmdRotateRight);
    }
    
    
    #region MOVEMENT_CMD

    private CmdMovement _cmdMoveForward;
    private CmdMovement _cmdMoveBack;
    private CmdRotate _cmdRotateLeft;
    private CmdRotate _cmdRotateRight;

    private void InitMovementCommands()
    {
        _cmdMoveForward = new CmdMovement(transform, Vector3.forward, _characterStats.MovementSpeed);
        _cmdMoveBack = new CmdMovement(transform, -Vector3.forward, _characterStats.MovementSpeed);
        _cmdRotateLeft = new CmdRotate(transform, -Vector3.up, _characterStats.RotateSpeed);
        _cmdRotateRight = new CmdRotate(transform, Vector3.up, _characterStats.RotateSpeed);
    }
    
    #endregion

    
}
