using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class Hero : MonoBehaviour
{
    public GameData data;

    public PlayerStateMachine playerStateMachine {  get; private set; }
    public Animator animator;
    public Rigidbody2D rb;

    public Health healthUI;

    private bool isLeak;

    public CameraShake cameraShake;

    private AudioSource audio;

    private bool isPause;

    public static int startGameid = 1;
    public float gameTime;
    public PausePanel pausePanel;

    [Header("Move Info")]
    public float moveSpeed;
    public float jumpForce;


    [Header("Dash Info")]
    public float dashSpeed;
    public float dashUsageTimer;//为dash设置冷却时间，在一定时间内不能连续使用
    public float dashCooldown;
    public float dashDuration;//持续时间

    [Header("Collision Info")]
    [SerializeField] private float groundCheckDistance;  
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private LayerMask whatIsGround;

    [Header("PlayerHealth")]
    [SerializeField] public int health = 5;
    [SerializeField] public int GeoNum;
    [SerializeField] public int soulOrbIndex;


   


    private void Awake()
    {
        Load();
        playerStateMachine = new PlayerStateMachine(this);
        BaseUIManager.MainInstance.OpenPanel(UIConst.PlayerHealthUI);
    }
    private void Start()
    {
        playerStateMachine.ChangeState(playerStateMachine.IdleState);
        cameraShake = FindObjectOfType<CameraShake>();
        audio = GetComponent<AudioSource>();
        if (!PlayerState.isFirstLand)
        {
            FindObjectOfType<SoulOrb>().DelayShowOrb();
        }
    }
    private void Update()
    {
        playerStateMachine.Update();
        PauseGame();
        gameTime += Time.deltaTime;
        CheckIsDead();
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + wallCheckDistance, transform.position.y));
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundCheckDistance));
    }
    private void PauseGame()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            isPause = !isPause;

            if (isPause)
            {
                BaseUIManager.MainInstance.OpenPanel(UIConst.PausePanel);
                pausePanel = FindObjectOfType<PausePanel>();
            }
            else
            {
                if(pausePanel != null)
                {
                    pausePanel.QuitPausePanel();
                }
                
            }
        }
        
    }
    #region 角色死亡检测
    private void CheckLeakHealth()
    {
        if(health == 1 && !isLeak)
        {
            isLeak = true;

        }
    }
    private void CheckIsDead()
    {
        if(health <= 0 && !PlayerState.isDead)
        {
            
            Die();
        }
    }
    private void Die()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"));
        PlayerState.isDead = true;
    }
    #endregion 
    #region 调用角色帧事件
    public void AnimationTrigger() => playerStateMachine.AnimationFinishTrigger();
    //从当前状态拿到AnimationTrigger进行调用的函数
    public void PlayMusic(AudioClip clip)
    {
        audio.PlayOneShot(clip);
    }
    public void ShowSoulOrb()
    {
        if (PlayerState.isFirstLand)
        {

            FindObjectOfType<SoulOrb>().DelayShowOrb();
        }
    }
    #endregion
    #region 地面检测
    public bool IsGroundDetected()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
    }
    #endregion
    #region 墙面检测
    public bool IsWallDetected()
    {
        return Physics2D.Raycast(transform.position,
            Vector2.right * PlayerState.facingDir,
            wallCheckDistance, whatIsGround);
    }
    #endregion
    #region 受伤检测
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 检测与敌人的碰撞
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerState.isHit = true;
            LoseHealth(1);
        }
    }
    public void LoseHealth(int health)
    {
        FindObjectOfType<Health>().Hit();//UI
        this.health -= health;
    }
    #endregion
    #region 数据的加载
    public void Load()
    {

        LoadByJosn();
        LoadData();

    }
    public bool LoadByJosn()
    {
        data = new GameData();
        data = SaveSystem.LoadFromJSON<GameData>(startGameid.ToString());
        Debug.Log(data);
        if (data != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void LoadData()
    {
        if (LoadByJosn())
        {
            transform.position = data.position;
            this.GeoNum = data.GeoNum;
            health = data.health;
            soulOrbIndex = data.soulOrb;
        }
        else
        {
            
        }
    }
    #endregion
    #region 存档的数据
    [System.Serializable]
    public class GameData
    {
        public int Id;
        public string place;
        public string time;
        public string scene;
        public Vector3 position;
        public int GeoNum;
        public int health;
        public int Geo;
        public int soulOrb;
    }
    #endregion
}
