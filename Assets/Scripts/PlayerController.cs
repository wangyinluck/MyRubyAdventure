
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 控制角色移动.生命.动画等
/// </summary>

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;//移动速度

    private int maxHealth = 5;//最大生命值

    private int currentHealth;//当前生命值
    
    public  int MyMaxHealth { get { return maxHealth; } }
    
    public  int MyCurrentHealth { get { return currentHealth; } }

    private float invincibleTime = 2f;//无敌时间2秒

    private float invincibleTimer;//无敌计时器

    private bool isInvincible;//是否处于无敌状态

    public GameObject bulletPrefab;//子弹
    
    //=======玩家的朝向===============

    private Vector2 lookDirection = new Vector2(1, 0);//默认朝向右方
    
    private Rigidbody2D rbody;//刚体组件
    private Animator anim;
    void Start() {
        currentHealth = 2; 
        invincibleTime = 0;
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        UImanager.instance.UpdateHealthBar(currentHealth, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");//控制水平移动方向 A:-1 D:1 0

        float moveY = Input.GetAxisRaw("Vertical");//控制垂直移动方向 W：1  S：-1 0

        Vector2 moveVector = new Vector2(moveX, moveY);
        if (moveVector.x != 0 || moveVector.y != 0) {
            lookDirection = moveVector;
            

        }

        anim.SetFloat("Look X", lookDirection.x);
        anim.SetFloat("Look Y", lookDirection.y);
        anim.SetFloat("Speed", moveVector.magnitude);
      //============移动=====================================================
        Vector2 position = rbody.position;
       // position.x += moveX * speed * Time.deltaTime;
        //position.y += moveY * speed * Time.deltaTime;
        position += moveVector * speed * Time.deltaTime;
        rbody.MovePosition(position);
        
        //=========无敌计时===================================================
        if (isInvincible) {
            invincibleTime -= Time.deltaTime;
            if (invincibleTime<0) {
                isInvincible = false;//倒计时结束以后（2秒），取消无敌状态

            }
        }
        //=======按下J键开始攻击
        if (Input.GetKeyDown(KeyCode.J))
        {
            anim.SetTrigger("Launch");//播放攻击动画
            GameObject bullet = Instantiate(bulletPrefab, rbody.position+Vector2.up*0.5f , Quaternion.identity);
            BulletController bc = bullet.GetComponent<BulletController>();
            if (bc != null) {
                bc.Move(lookDirection,300);
                
            }

        }
    }
/// <summary>
/// 改变玩家生命值
/// </summary>
/// <param name="amount"></param>
    public void ChangeHealth(int amount){
    //如果玩家受到伤害
    if (amount < 0) {
        if (isInvincible==true){
            return;
        }
        isInvincible = true;
        anim.SetTrigger("Hit");
        invincibleTimer = invincibleTime;
    }
    
    //把玩家的生命值约束在0和最大值之间
     currentHealth = Mathf.Clamp(currentHealth + amount,0,maxHealth);
     UImanager.instance.UpdateHealthBar(currentHealth, maxHealth);//更新血条
     Debug.Log(currentHealth +"/"+maxHealth);
    }
}
