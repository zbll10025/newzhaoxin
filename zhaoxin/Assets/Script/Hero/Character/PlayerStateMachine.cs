using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine 
{
    public Hero hero { get; private set; }
    public PlayerState PlayerState { get; private set; }
    public GroundState GroundState{get; private set;}
    public MoveState MoveState { get; private set; }
    public IdleState IdleState { get; private set;}
    public JumpState JumpState { get; private set; }
    public AirState AirState { get; private set; }
    public WallSlideState WallSlideState { get; private set; }
    public WallJumpState WallJumpState { get; private set; }
    public PrimaryAttack PrimaryAttack { get; private set; }
    public ChargeState ChargeState { get; private set; }
    public ChargeAttack1 ChargeAttack1 { get; private set; }
    public AttackState AttackState { get; private set; }
    public UpAttackState UpAttackState { get; private set; }
    public DownAttack DownAttack { get; private set; }
    public DashState DashState { get; private set; }
    public TakeDamageState TakeDamageState { get; private set; }
    public FirstLandState FirstLandState { get; private set; }
    public PlayerStateMachine(Hero hero)
    {
        this.hero = hero;
        PlayerState = new PlayerState(this);
        GroundState = new GroundState(this);
        MoveState = new MoveState(this);
        IdleState = new IdleState(this);
        JumpState = new JumpState(this);
        AirState = new AirState(this);
        WallSlideState = new WallSlideState(this);
        WallJumpState = new WallJumpState(this);
        PrimaryAttack = new PrimaryAttack(this);
        ChargeState = new ChargeState(this);
        ChargeAttack1 = new ChargeAttack1(this);
        UpAttackState = new UpAttackState(this);
        AttackState = new AttackState(this);
        DownAttack = new DownAttack(this);
        DashState = new DashState(this);
        TakeDamageState = new TakeDamageState(this);
        FirstLandState = new FirstLandState(this);
    }
}
