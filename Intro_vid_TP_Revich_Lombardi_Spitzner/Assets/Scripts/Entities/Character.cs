using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IMoveable
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

    // [SerializeField] private KeyCode _attack = KeyCode.Mouse0;
    // [SerializeField] private KeyCode _reload = KeyCode.R;

    // [SerializeField] private KeyCode _GunSlot1 = KeyCode.Alpha1;
    // [SerializeField] private KeyCode _GunSlot2 = KeyCode.Alpha2;
    // [SerializeField] private KeyCode _GunSlot3 = KeyCode.Alpha3;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
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

        if (Input.GetKey(_moveBack)) Move(Vector3.back);
        if (Input.GetKey(_moveLeft)) Turn(-Vector3.up);
        if (Input.GetKey(_moveRight)) Turn(Vector3.up);
        if (Input.GetKeyDown(_jump) || Input.GetKey(_jump)) animator.SetBool("jumping", true);
        else
        {
            animator.SetBool("jumping", false);
        }

        

        // if (Input.GetKeyDown(_attack)) _currentGun.Shoot();
        // if (Input.GetKeyDown(_reload)) _currentGun.Reload();

        // if (Input.GetKeyDown(_GunSlot1)) SwitchGun(0);
        // if (Input.GetKeyDown(_GunSlot2)) SwitchGun(1);
        // if (Input.GetKeyDown(_GunSlot3)) SwitchGun(2);
    }

    #region IMOVEABLE_ACTIONS
    public float MovementSpeed => _movementSpeed;
    [SerializeField] private float _movementSpeed = 5.5f;

    public float TurnSpeed => _turnSpeed;
    [SerializeField] private float _turnSpeed = 25f;
    public void Move(Vector3 direction) => transform.Translate(direction * Time.deltaTime * _movementSpeed);
    public void Turn(Vector3 direction) => transform.Rotate(direction * Time.deltaTime * _turnSpeed, Space.Self);
    #endregion

    // private void SwitchGun(int index)
    // {
    //     foreach (Gun gun in _guns)
    //     {
    //         gun.gameObject.SetActive(false);
    //     }
    //     _guns[index].gameObject.SetActive(true);
    //     _currentGun = _guns[index];
    // }

}
