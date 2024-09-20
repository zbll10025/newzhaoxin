using BehaviorDesigner.Runtime.Tasks.Unity.UnityInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestPlayerMove : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed;
    public Vector2 velocity;
    public float jumpForce;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
       

        if (body == null)
        {

            enabled = false;
        }
        body.velocity = new Vector2(body.velocity.x, -5f);
        velocity = body.velocity;

    }
    private void Update()
    {
        body.velocity = velocity;
        Jump();
    }
    public void Move(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        velocity = new Vector2(direction.x * speed, body.velocity.y);

    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Vector2 jdir = new Vector2(0, 1);
            body.AddForce(jumpForce * jdir, ForceMode2D.Impulse);
        }
    }
    //这个是测试敌人ai写的player移动代码
}