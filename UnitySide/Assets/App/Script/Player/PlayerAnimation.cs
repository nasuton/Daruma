using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player
{
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
