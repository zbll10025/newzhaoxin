using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerState : IState
{
    public static int facingDir = 1;
    public static bool facingRight = true;//判断是否朝右
    public static bool isCharge;
    public static bool isDashing;
    public static bool isHit;
    public static bool isFirstLand;

    protected float jumpHandTimeThreshold = 0.1f;//设置跳跃暂停阈值，使动作丝滑

    protected bool triggerCalled = true;//动画是否完成控制值


    protected Animator anim { get; private set; }
    protected Rigidbody2D rb;

    protected PlayerStateMachine stateMachine {  get; private set; }

    
    public float xInput;
    public PlayerState( PlayerStateMachine playerStateMachine)
    {
        stateMachine = playerStateMachine;
        //简化名称，如：playerStateMachine.hero.rb->rb
        anim = playerStateMachine.hero.animator;

        rb = playerStateMachine.hero.rb;

    }
    public virtual void Enter()
    {
        Debug.Log(GetType().Name);
    }

    public virtual void Exit()
    {
        
    }

    public void HandInput()
    {
        
    }
    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }//动画控制函数，当动画完成时将控制器设置为true表达其动画已经完成了

    public virtual void Update()
    {
        xInput = PlayerInputSystem.MainInstance.PlayerXMove.x;
        anim.SetFloat(AnimatorID.YVelocityID, rb.velocity.y);
        if(Input.GetKeyDown(KeyCode.X))//受伤测试
        {
            stateMachine.ChangeState(stateMachine.TakeDamageState);
        }
        

        if (triggerCalled && !isCharge && !isHit)//检测是否在攻击状态或受伤状态
        {
            CheckForDashInput();
            if(!isDashing)//不在冲刺状态
            {
                DetectPlayerAttack();//攻击
            }
        }
        
    }
        
    #region 设置角色移动速度
    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);//在设置速度的时候调用翻转控制器
    }
    public void ZeroVelocity()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }
    #endregion
    #region 反转人物
    public void Flip()
    {
        facingDir *= -1;
        facingRight = !facingRight;
        stateMachine.hero.transform.Rotate(0, 180, 0);
    }
    public void FlipController(float _x)//目前设置x，目的时能在空中时也能转身
    {
        if (_x > 0 && !facingRight)//当速度大于0且没有朝右时，翻转
        {
            Flip();
        }
        else if (_x < 0 && facingRight)
        {
            Flip();
        }
    }
    #endregion
    #region 设置重力尺度
    public void SetGravityScale(float scale)//默认尺度为1
    {
        rb.gravityScale = scale;
    }
    #endregion
    #region 攻击检测
    public void DetectPlayerAttack()
    {
        if (PlayerInputSystem.MainInstance.PrimaryAttack &&
                PlayerInputSystem.MainInstance.PlayerXMove.y > 0)//上攻击
        {
            Debug.Log(true);
            stateMachine.ChangeState(stateMachine.UpAttackState);
            return;
        }
        if (PlayerInputSystem.MainInstance.PrimaryAttack)//普通攻击
        {
            stateMachine.ChangeState(stateMachine.PrimaryAttack);
            return;
        }
        if (PlayerInputSystem.MainInstance.Charge)//蓄力攻击
        {
            stateMachine.ChangeState(stateMachine.ChargeState);
            return;
        }            
    }
    #endregion
    #region 冲刺检测
    public void CheckForDashInput()
    {
        stateMachine.hero.dashUsageTimer -= Time.deltaTime;//给dash上冷却时间

        if (PlayerInputSystem.MainInstance.Dash && stateMachine.hero.dashUsageTimer < 0)
        {

            stateMachine.hero.dashUsageTimer = stateMachine.hero.dashCooldown;
            stateMachine.ChangeState(stateMachine.DashState);
        }
    }
    #endregion
    #region 受伤检测

    #endregion
}
