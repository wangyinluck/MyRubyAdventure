using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///  控制子弹的移动，碰撞
/// </summary>

public class BulletController: MonoBehaviour {
    
     Rigidbody2D rbody;
    
    void Awake() {
        rbody = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 2f);
    }

    // Update is called once per frame
    void Update() {
        
        
    }
    /// <summary>
    /// 子弹的移动
    /// </summary>
    /// <param name="moveDirection"></param>

    public void Move(Vector2 moveDirection,float moveForce) {
        rbody.AddForce(moveDirection *moveForce );
    }

    ///碰撞检测
    private void OnCollisionEnter2D(Collision2D other)
    {
       EnemyController  ec = other.gameObject.GetComponent<EnemyController >();
       if (ec != null)
       {
           ec.Fixsd();//修复敌人
           Debug .Log("碰到敌人了");
           
       }

        Destroy(this.gameObject);

    }
}
