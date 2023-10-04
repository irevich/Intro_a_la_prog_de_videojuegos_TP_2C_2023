using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student : Actor
{
    public Animator animator;

    public StudentStats StudentStats => _studentStats;
    [SerializeField] private StudentStats _studentStats;

    private CharacterMovementController _characterMovementController;

    #region KEY_BINDINGS

    [SerializeField] private KeyCode _moveForward = KeyCode.W;
    [SerializeField] private KeyCode _moveBack = KeyCode.S;
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;
    [SerializeField] private KeyCode _jump = KeyCode.Space;
    [SerializeField] private KeyCode _slide = KeyCode.LeftControl;

    #endregion

    void Start()
    {
        _characterMovementController = GetComponent<CharacterMovementController>();
        base._entityStats = _studentStats;
        base.Start();
        InitMovementCommands();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(_moveForward))
        {
            _cmdMoveForward.Do();
            animator.SetFloat("walking", 1);
        }
        else animator.SetFloat("walking", 0);

        if (Input.GetKeyDown(_moveForward))
            animator.SetFloat("walking", 1);

        if (Input.GetKey(_moveBack))
        {
            _cmdMoveBack.Do();
            animator.SetBool("backwards", true);
        }

        else animator.SetBool("backwards", false);

        if (Input.GetKey(_moveLeft))
        {
            _cmdRotateLeft.Do();
        }


        if (Input.GetKey(_moveRight))
        {
            _cmdRotateRight.Do();
        }


        if (Input.GetKeyDown(_jump) || Input.GetKey(_jump)) animator.SetBool("jumping", true);
        else
        {
            animator.SetBool("jumping", false);
        }

        if (Input.GetKey(_slide)) animator.SetBool("slide", true);
        else
        {
            animator.SetBool("slide", false);
        }
    }

    #region MOVEMENT_CMD

    private CmdMovement _cmdMoveForward;
    private CmdMovement _cmdMoveBack;
    private CmdRotate _cmdRotateLeft;
    private CmdRotate _cmdRotateRight;

    private void InitMovementCommands()
    {
        _cmdMoveForward = new CmdMovement(_characterMovementController, Vector3.forward);
        _cmdMoveBack = new CmdMovement(_characterMovementController, -Vector3.forward);
        _cmdRotateLeft = new CmdRotate(_characterMovementController, -Vector3.up);
        _cmdRotateRight = new CmdRotate(_characterMovementController, Vector3.up);
    }

    #endregion

    /*
    #region IMOVEABLE_ACTIONS

    public float MovementSpeed => _studentStats.MovementSpeed;

    public float TurnSpeed => _studentStats.RotateSpeed;

    public void Move(Vector3 direction) => transform.Translate(direction * MovementSpeed
                                                                         * Time.deltaTime);

    public void Turn(Vector3 direction) => transform.Rotate(direction * TurnSpeed
                                                                      * Time.deltaTime, Space.Self);

    #endregion
    */
}