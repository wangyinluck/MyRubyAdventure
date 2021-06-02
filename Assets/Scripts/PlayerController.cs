
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
    
    private Rigidbody2D rbody;//刚体组件
    void Start() {
        currentHealth = 2;
        invincibleTime = 0;
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");//控制水平移动方向 A:-1 D:1 0

        float moveY = Input.GetAxisRaw("Vertical");//控制垂直移动方向 W：1  S：-1 0
      //============移动=====================================================
        Vector2 position = rbody.position;
        position.x += moveX * speed * Time.deltaTime;
        position.y += moveY * speed * Time.deltaTime;
        rbody.MovePosition(position);
        
        //=========无敌计时===================================================
        if (isInvincible) {
            invincibleTime -= Time.deltaTime;
            if (invincibleTime<0) {
                isInvincible = false;//倒计时结束以后（2秒），取消无敌状态

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
        invincibleTimer = invincibleTime;
    }
    
    //把玩家的生命值约束在0和最大值之间
     currentHealth = Mathf.Clamp(currentHealth + amount,0,maxHealth);
     
     Debug.Log(currentHealth +"/"+maxHealth);
    }
}
