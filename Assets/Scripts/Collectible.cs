using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
/// <summary>
/// 草莓被玩家碰撞时检测的相关类
/// </summary>
public class Collectible: MonoBehaviour
{

    public ParticleSystem collecteffect;//拾取特效
    
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    ///</summary>
    /// 碰撞检测相关
    /// </summary>
    /// <param name="oher></param>
     void OnTriggerEnter2D(Collider2D other)
    {
        Debug .LogError("发生了碰撞");
        PlayerController pc = other.GetComponent<PlayerController>();
        if (pc != null) ;
        {
            if (pc.MyCurrentHealth < pc.MyMaxHealth) {
             pc .ChangeHealth(1);

             Instantiate(collecteffect , transform.position, Quaternion.identity);//生成特效
             
             Destroy(this.gameObject);
            }
           
           
        }

    }
}
