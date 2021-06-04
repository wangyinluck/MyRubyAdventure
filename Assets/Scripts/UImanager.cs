using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine .UI;

/// <summary>
/// UI管理相关
/// </summary>
public class UImanager : MonoBehaviour {
   //单列模式
   public static UImanager instance { get; private set; }

   void Start()
   {
      instance = this;

   }

   public Image healthBar;//角色的血条
   /// <summary>
   /// 更新血条
   /// </summary>
   /// <param name="curAmount"></param>
   /// <param name="maxAmount"></param>

   public void UpdateHealthBar(int curAmount, int maxAmount)
   {

      healthBar.fillAmount = (float) curAmount / (float)maxAmount;
   }
}


