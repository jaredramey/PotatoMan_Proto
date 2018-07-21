using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Player_Controller : MonoBehaviour
{
    #region Variables
    private Rigidbody playerBody;
    private Animator playerAnimator;
    [SerializeField]
    public float downwardForce = 0.0f;
    [SerializeField]
    public float moveForce = 0.0f;
    [SerializeField]
    public float jumpForce = 0.0f;
    [HideInInspector]
    private bool canJump = true;
    [HideInInspector]
    private Vector3 movement;
    #endregion


    // Use this for initialization
    void Start()
    {
        #region Variable_Init
        playerBody = gameObject.GetComponent<Rigidbody>();
        playerAnimator = gameObject.GetComponent<Animator>();
        movement = new Vector3(0,0,0);
        #endregion

        #region Input_Listeners
        Player_InputManager.Instance.OnMoveForward.AddListener(Handle_OnMoveForward);
        Player_InputManager.Instance.OnMoveBackwards.AddListener(Handle_OnMoveBackward);
        Player_InputManager.Instance.OnMoveUp.AddListener(Handle_OnMoveUp);
        Player_InputManager.Instance.OnMoveDown.AddListener(Handle_OnMoveDown);
        Player_InputManager.Instance.OnJump.AddListener(Handle_OnJump);
        Player_InputManager.Instance.OnRegularAttack.AddListener(Handle_OnRegAttack);
        Player_InputManager.Instance.OnJumpingAttack.AddListener(Handle_OnJumpAttack);
        #endregion
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement = new Vector3(Player_InputManager.Instance.horizontal, 0.0f, Player_InputManager.Instance.vertical);
        playerBody.AddForce(movement * moveForce);
    }

    private void Handle_OnMoveForward()
    {
        //Move X+
        //playerBody.AddForce(((Vector3.forward) * moveForce) * -Player_InputManager.Instance.horizontal);
        //playerBody.AddForce(movement * moveForce);
        if (transform.rotation.y != 0)
        {
            transform.Rotate(new Vector3(0, 0, 0));
        }
    }

    private void Handle_OnMoveBackward()
    {
        //Move X-
        //playerBody.AddForce(((Vector3.forward) * moveForce) * -Player_InputManager.Instance.horizontal);
        //playerBody.AddForce(movement * moveForce);
        if (transform.rotation.y != 180)
        {
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    private void Handle_OnMoveUp()
    {
        //Move Z+
        //playerBody.AddForce(((Vector3.left) * moveForce) * -Player_InputManager.Instance.vertical);
        //playerBody.AddForce(movement * moveForce);
    }

    private void Handle_OnMoveDown()
    {
        //Move Z-
        //playerBody.AddForce(((Vector3.left) * moveForce) * -Player_InputManager.Instance.vertical);
        //playerBody.AddForce(movement * moveForce);
    }

    private void Handle_OnJump()
    {
        //TODO: Add jump
    }

    private void Handle_OnRegAttack()
    {
        //TODO: Add Attack
    }

    private void Handle_OnJumpAttack()
    {
        //TODO: Add JumpAttack
    }
}
