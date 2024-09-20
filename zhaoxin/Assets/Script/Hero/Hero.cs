using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class Hero : MonoBehaviour
{
    public PlayerStateMachine playerStateMachine {  get; private set; }
    public Animator animator;
    public Rigidbody2D rb;


    [Header("Move Info")]
    public float moveSpeed;
    public float jumpForce;


    [Header("Dash Info")]
    public float dashSpeed;
    public float dashUsageTimer;//Ϊdash������ȴʱ�䣬��һ��ʱ���ڲ�������ʹ��
    public float dashCooldown;
    public float dashDuration;//����ʱ��

    [Header("Collision Info")]
    [SerializeField] private float groundCheckDistance;  
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private LayerMask whatIsGround;

    public CameraShake cameraShake;

    private AudioSource audio;

    private bool isPause;

    public PausePanel pausePanel;
    private void Awake()
    {
        playerStateMachine = new PlayerStateMachine(this);
        BaseUIManager.MainInstance.OpenPanel(UIConst.PlayerHealthUI);
    }
    private void Start()
    {
        playerStateMachine.ChangeState(playerStateMachine.IdleState);
        cameraShake = FindObjectOfType<CameraShake>();
        audio = GetComponent<AudioSource>();
        if(!PlayerState.isFirstLand)
        {
            FindObjectOfType<SoulOrb>().DelayShowOrb();
        }
    }
    private void Update()
    {
        playerStateMachine.Update();
        PauseGame();


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
                    Debug.Log(true);
                    pausePanel.QuitPausePanel();
                }
                
            }
        }
        
    }
    #region ���ý�ɫ֡�¼�
    public void AnimationTrigger() => playerStateMachine.AnimationFinishTrigger();
    //�ӵ�ǰ״̬�õ�AnimationTrigger���е��õĺ���
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
    #region ������
    public bool IsGroundDetected()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
    }
    #endregion
    #region ǽ����
    public bool IsWallDetected()
    {
        return Physics2D.Raycast(transform.position,
            Vector2.right * PlayerState.facingDir,
            wallCheckDistance, whatIsGround);
    }
    #endregion
}
