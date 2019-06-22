using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerController : MonoBehaviour
{
    private Rigidbody2D rbody = null;
    private SpriteRenderer spriteRenderer = null;
    private Animator animator = null;
    [SerializeField] float movementSpeed = 1.0f;

    private void Initialize()
    {
        rbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        Vector2 inputVector = KeyConfigManager.Instance.GetLeftAnalogStickValue();
        //使っている左アナログスティックの上の値が0より下の値で来るため-1をかける
        //不要の場合はコメントアウトする
        inputVector.y *= -1.0f;
        inputVector = Vector2.ClampMagnitude(inputVector, 1.0f);
        PlayerDirection(inputVector);
        Vector2 movement = inputVector * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        rbody.MovePosition(newPos);
    }

    private void PlayerDirection(Vector2 direction)
    {
        //何も入力されていなければ返す
        if (direction == Vector2.zero)
        {
            animator.SetBool("isRunning", false);
            return;
        }

        ////入力された方向に応じて向きを変える
        if (direction.x > 0.0f)
        {
            spriteRenderer.flipX = false;
        }
        else if (direction.x < 0.0f)
        {
            spriteRenderer.flipX = true;
        }

        animator.SetBool("isRunning", true);
    }

}
