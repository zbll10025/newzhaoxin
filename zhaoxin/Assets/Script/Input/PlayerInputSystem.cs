using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using zhou.Tool.Singleton;

public class PlayerInputSystem : Singleton<PlayerInputSystem>
{
    public PlayerInputAction inputAction;
    public Vector2 PlayerXMove => inputAction.Player.Move.ReadValue<Vector2>();
    public bool Jump => inputAction.Player.Jump.phase == InputActionPhase.Performed;
    public bool JumpCancel => inputAction.Player.Jump.phase == InputActionPhase.Canceled;
    public bool PrimaryAttack => inputAction.Player.PrimaryAttack.triggered;
    public bool Charge => inputAction.Player.PrimaryAttack.phase == InputActionPhase.Performed;
    public bool Dash => inputAction.Player.Dash.triggered;
   // public bool Pause => inputAction.Player.Pause.phase == InputActionPhase.Started;
    protected override void Awake()
    {
        base.Awake();
        inputAction ??= new PlayerInputAction();
    }
    private void OnEnable()
    {
        inputAction.Enable();
    }
    private void OnDisable()
    {  
        inputAction.Disable();
    }
}
