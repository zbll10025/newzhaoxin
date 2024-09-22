using Assets.Script.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using System.Runtime.InteropServices.WindowsRuntime;
using JetBrains.Annotations;
public class BaseEnemy : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    [HideInInspector]
    public Transform Enemytransform;
    [HideInInspector]
    public Rigidbody2D rig;
    [HideInInspector]
    public float currentscal;
    [HideInInspector]
    //"���������ļ�"
    public MostData_SO mostdata_So;
    [Header("��ʼ�����")]
    public bool isRightLocalscal;
    public int Id;
    [Header("�ٶ�")]
    public float patorlSpeed;
    public float rushSpeed;
    public float currentsSpeed;
    public float dashSpeed=8;
    public Animator ani;
    [Header("״̬")]
    public float hp;
    public bool isdead;
    public bool ishit;
    public bool isGround;
    public bool isJump;
    public bool isDash;
    [Header("����")]
    public float attackValue;
    [Header("�����")]
    public float dashForce;
    public float hitForce;
    //"��������������"
    [HideInInspector]
    public AttackAreac AttackAreac;
    [HideInInspector]
    public PlayerCheck playerCheck;
    [HideInInspector]
    public Transform attackAlarm;
    [HideInInspector]
    public SpriteRenderer spriteRenderer;
    //"������"
    [HideInInspector]
    public GameObject player;
    [HideInInspector]
    public Vector2 playerDirection;
    [HideInInspector]
    public float playerDistance;
    [HideInInspector]
    public float playerPositionOffest;
    [Header("�������")]
    public float groundCheckDistance;
    public LayerMask whatIsGround;
    protected  virtual void Awake()
    {
       
        Enemytransform = GetComponent<Transform>();
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(transform.Find("PlayerCheck")!=null)
        playerCheck = transform.Find("PlayerCheck").GetComponent<PlayerCheck>();
        if(transform.Find("AttackAcrea")!=null)
        AttackAreac = transform.Find("AttackAcrea").GetComponent<AttackAreac>();
       // rig.velocity = new Vector2 (1, 1);
        ReadMostData_So();
        currentscal = Enemytransform.localScale.x;
        currentsSpeed = patorlSpeed;
        isGround = IsGroundDetected();
        ishit = false;


    }


    protected virtual void Update()
    {

        //�����ж�����L
        if(Input.GetKeyDown(KeyCode.L)){
            isdead = true;
        }
        //���������ж�
        if (Input.GetKeyDown(KeyCode.P))
        {
           
            Onhit();
        }
        isGround = IsGroundDetected();
        if (isJump)
        {
           
            CheckAniFallState();
        }

        
    }
     public virtual void Onhit()
        {
            ishit = true;
            Vector2 a = -playerDirection.normalized * hitForce;
            rig.AddForce(a, ForceMode2D.Impulse);
            hp -= 20;
            HitFixDir();
        }
    /// <summary>
    /// ����ת��
    /// </summary>
    public void HitFixDir()
    {
        if (!isRightLocalscal)
        {
            if (-playerDirection.x > 0)
            {
                this.gameObject.transform.localScale = new Vector3(1, 1);
            }
            else
            {
                this.gameObject.transform.localScale = new Vector3(-1, 1);
            }
        }
        else
        {
            if (playerDirection.x > 0)
            {
                this.gameObject.transform.localScale = new Vector3(1, 1);
            }
            else
            {
                this.gameObject.transform.localScale = new Vector3(-1, 1);
            }

        }
    }
    public virtual void Cancel_isHit()
    {
        ishit = false;
    }
    public virtual void Cancel_isJump()
    {
        isJump = false;
    }
    public virtual void CancelAni_isJump()
    {
        ani.SetBool("isJump", false);
        ani.SetBool("isFall", false);
    }
    public virtual void Onstart_isJump()
    {
        isJump = true;
    }
  
    public virtual void FixDirc()
            {
                BaseEnemy landEnemy = this.GetComponent<BaseEnemy>();

                if (!landEnemy.isRightLocalscal)
                {
                    if (-landEnemy.playerDirection.x > 0)
                    {
                        landEnemy.gameObject.transform.localScale = new Vector3(1, 1, 1);
                    }
                    else
                    {
                        landEnemy.gameObject.transform.localScale = new Vector3(-1, 1, 1);
                    }
                }
                else
                {
                    if (landEnemy.playerDirection.x > 0)
                    {
                        landEnemy.gameObject.transform.localScale = new Vector3(1, 1, 1);
                    }
                    else
                    {
                        landEnemy.gameObject.transform.localScale = new Vector3(-1, 1, 1);
                    }
                }
            }

    public virtual void GetPlayerDistance()
    {
        GetPlayerObject();
        if (player != null)
            playerDistance = math.abs(player.transform.position.x - Enemytransform.position.x);
    }
    //��ȡ���������x��ľ���
    public virtual void GetPlayerDirction()
    {
        Vector3 offeset = new Vector3(0, playerPositionOffest,0);
        GetPlayerObject();
        if (player != null)
            playerDirection = (player.transform.position - Enemytransform.position+offeset).normalized;
    }

    public void GetPlayerObject()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");

        }
    }

    public void ReadMostData_So()
    {
        mostdata_So = Resources.Load<MostData_SO>("So/MostData_So");
        MostData mostData = mostdata_So.mostdataList.Find(i => i.Id == this.Id);
        if (mostData == null)
        {
            return;
        }
        #region ��ȡ��������
        mostdata_So.Initialize(this);
        #endregion
    }

    
    
   /// <summary>
   /// �������->������
   /// </summary>
   /// <returns></returns>
     public bool IsGroundDetected()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    private void OnDrawGizmos()
    {
        
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundCheckDistance));
    }

    public virtual void CheckAniFallState()
    {
        float velocity_y = rig.velocity.y;
        if (!isGround && velocity_y <=0)
        {
            ani.SetBool("isFall", true);
        }
        else
        {
            ani.SetBool("isFall", false);
        }
    }

    public bool BehindPlayerCheck()
    {
        float value = (player.transform.position.x - this.transform.position.x) * this.transform.localScale.x;
        if (isRightLocalscal)
        {
            if (value < 0)
            {
               
                return true;
            }else
            {
              
                return false;
            }
        }else
        {
            if (value > 0)
            {
              
                return true;
            }
            else
            {
               
                return false;
            }
        }
    }

    protected Vector2 dashDir;
    public void MostDash()
    {
         FixDirc();
       dashDir = playerDirection.normalized;
        
        rig.AddForce(dashDir * dashForce, ForceMode2D.Impulse);
        
    }
}
