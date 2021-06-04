using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
/// <summary>
/// 敌人控制相关
/// </summary>
public class EnemyController : MonoBehaviour
{
    public float speed = 3;//移动

    public float changeDirectionTime = 2f;//改变方向的时间
    
    public bool isVertical;//是否垂直方向移动

    private float changeTimer;//改变方向的计时器

    private Vector2 moveDirection;//移动方向
    
    private Rigidbody2D rbody;

    private Animator anim;
    // Use this for initialization
    void Start()
    {

        rbody = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
        
        moveDirection = isVertical ? Vector2.up : Vector2.right;//如果是垂直移动，方向就朝上；否则方向朝右

        changeTimer = changeDirectionTime;
    }

    // Update is called once per frame
    void Update()
    {
        changeTimer -= Time.deltaTime;
        if (changeTimer < 0)
        {
            moveDirection *= -1;
            changeTimer = changeDirectionTime;
        }

        Vector2 position = rbody.position;
        position.x += moveDirection.x * speed * Time.deltaTime;
        position.y += moveDirection.y * speed * Time.deltaTime;
        rbody .MovePosition(position );
        anim.SetFloat("moveX",moveDirection.x);
        anim.SetFloat("moveY",moveDirection.y);
        
        
    }
    /// <summary>
    /// 与玩家的碰撞检测
    /// </summary>
    /// <param name="other"></param>

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController pc = other.gameObject.GetComponent<PlayerController>();
        if (pc != null) {
            pc.ChangeHealth(-1);
            
        }
        


    }
    /// <summary>
    /// 敌人被修复
    /// </summary>
    public void Fixsd() 
    
}

