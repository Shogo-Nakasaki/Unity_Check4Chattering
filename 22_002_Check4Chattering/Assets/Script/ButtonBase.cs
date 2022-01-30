/** --------------------------------------------------
 *  @file   ButtonBase.cs
 *  @brief  ボタン処理の継承元となるスクリプト
 *  @author ShogoN
 *  @date   2022.1.30
 -------------------------------------------------- */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

/** --------------------------------------------------
 *  @class  ButtonBase
 *  @brief  ボタン処理の継承元
 *  
 -------------------------------------------------- */
public class ButtonBase : MonoBehaviour
{
    public ButtonBase button;
    protected virtual void Update() {}

    /** --------------------------------------------------
     *  @fn     Onclick()
     *  @brief  クリック時の処理
     *  
     -------------------------------------------------- */
    public void OnClick()
    {
        // ボタンが無かったときに出すログ
        if(button == null)
        {
            throw new System.Exception("Button instance is null");
        }
        button.OnClick(this.gameObject.name);
    }

    protected virtual void OnClick(string objectName)
    {
        // 呼ばれることのないログ
        Debug.Log("Base Button");
    }
}
