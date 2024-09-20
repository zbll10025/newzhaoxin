using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class TakeDamageState : PlayerState
{
    private SpriteRenderer render;
    private Color normalColor = new Color(1, 1, 1);
    private Color flashColor = new Color(1,0,0);

    public int blinkCount = 1;//��˸��

    private bool isBlinking = false; // �Ƿ�������˸
    private float timer = 0f; // ���ڼ�ʱ
    private int currentBlink = 0; // ��ǰ��˸����
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
        // �л���ɫ�Ŀɼ���
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
