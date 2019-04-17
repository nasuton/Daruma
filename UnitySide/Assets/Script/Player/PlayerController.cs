using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rbody = null;
    private Animator animator = null;
    static private int hashSpeed = Animator.StringToHash("Speed");
    [SerializeField] float movementSpeed = 1.0f;

    private void Initialize()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        Initialize();
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        Vector2 currentPos = rbody.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1.0f);
        animator.SetFloat(hashSpeed, inputVector.magnitude);
        PlayerDirection(inputVector.x);
        Vector2 movement = inputVector * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        rbody.MovePosition(newPos);
    }

    private void PlayerDirection(float direction)
    {
        //左右でなければ返す
        if(direction == 0.0f)
        {
            return;
        }

        //入力された方向に応じて向きを変える
        if(direction > 0.0f)
        {
            transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        }else if(direction < 0.0f)
        {
            transform.localEulerAngles = new Vector3(0.0f, -180.0f, 0.0f);
        }
    }
}
