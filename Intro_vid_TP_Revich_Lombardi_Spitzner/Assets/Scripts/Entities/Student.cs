using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student : Actor, IMoveable
{
    // [SerializeField] private List<Gun> _guns;
    // [SerializeField] private Gun _currentGun;
    public Animator animator;


    #region KEY_BINDINGS
    [SerializeField] private KeyCode _moveForward = KeyCode.W;
    [SerializeField] private KeyCode _moveBack = KeyCode.S;
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;
    [SerializeField] private KeyCode _jump = KeyCode.Space;
    [SerializeField] private KeyCode _slide = KeyCode.LeftControl;

    [SerializeField] private KeyCode _hurt = KeyCode.Return; //Enter for temporary simulate hurt
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        // SwitchGun(0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(_moveForward)) 
        {
            Move(Vector3.forward);
            animator.SetFloat("walking", 1);
        }
        else animator.SetFloat("walking", 0);
        if (Input.GetKeyDown(_moveForward)) animator.SetFloat("walking", 1);

        if (Input.GetKey(_moveBack)) 
        {
            Move(Vector3.back);
            animator.SetBool("backwards", true);
        }
        else animator.SetBool("backwards", false);
        if (Input.GetKey(_moveLeft)) Turn(-Vector3.up);
        if (Input.GetKey(_moveRight)) Turn(Vector3.up);
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

        //Simulate hurt
        if (Input.GetKeyDown(_hurt)) TakeDamage(5);

    }

    #region IMOVEABLE_ACTIONS
    public float MovementSpeed => _movementSpeed;
    [SerializeField] private float _movementSpeed = 5.5f;

    public float TurnSpeed => _turnSpeed;
    [SerializeField] private float _turnSpeed = 25f;
    public void Move(Vector3 direction) => transform.Translate(direction * Time.deltaTime * _movementSpeed);
    public void Turn(Vector3 direction) => transform.Rotate(direction * Time.deltaTime * _turnSpeed, Space.Self);
    #endregion


}
