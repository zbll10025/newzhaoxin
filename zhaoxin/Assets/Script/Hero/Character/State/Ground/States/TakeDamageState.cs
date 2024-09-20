using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class TakeDamageState : PlayerState
{
    private SpriteRenderer render;
    private Color normalColor = new Color(1, 1, 1);
    private Color flashColor = new Color(1,0,0);

    public int blinkCount = 1;//闪烁数

    private bool isBlinking = false; // 是否正在闪烁
    private float timer = 0f; // 用于计时
    private int currentBlink = 0; // 当前闪烁次数
    private float hurtForce = 5f;


    public TakeDamageState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
        
    }
    public override void Enter()
    {
        
        base.Enter();
        render = stateMachine.hero.GetComponent<SpriteRenderer>();
        anim.Play("TakeDamage");
        isHit = true;
        currentBlink = 0;
        DamageForce();
        stateMachine.hero.cameraShake.CinemaShake();
    }

    public override void Exit()
    {
        base.Exit();
        isHit = false;
    }
    public override void Update()
    {
        
        ZeroVelocity();
        timer += Time.deltaTime;
        if (timer >= 0.1f && !isBlinking)
        {
            Blinking();
        }else if(timer >= 0.2f)
        {
            ReturnRender();
        }
    }
    private void DamageForce()
    {
        if(facingRight)
        {
            rb.velocity = new Vector2(1,1)* hurtForce;
        }
        else
        {
            rb.velocity = new Vector2(-1, 1) * hurtForce;
        }
    }
    private void Blinking()
    {
        // 切换角色的可见性
        render.color = flashColor;
        isBlinking = true;
    }
    private void ReturnRender()
    {
        render.color = normalColor;
        timer = 0f;
        currentBlink++;
        isBlinking = false;
        if(currentBlink > blinkCount) 
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }
    
    
}
