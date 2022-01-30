/** -----------------------------------------------------------
 *  @file   ButtonMain.cs
 *  @brief  ボタン処理を記載
 *  @author ShogoN
 *  @date   2022.1.30
 *  
--------------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/** -----------------------------------------------------------
 *  @class  ButtonMain
 *  @brief  ボタン処理を記載
 *  
-------------------------------------------------------------*/
public class ButtonMain : ButtonBase
{
    [SerializeField] Text tex_push;
    [SerializeField] Text tex_time;
    [SerializeField] Text tex_interval;

    //! クリック回数で使う変数
    public int count_push = 0;

    //! クリック時間で使う変数
    public float count_time, count_time_a, count_time_b;
    public bool push = false;

    //! クリック感覚で使う変数
    public float count_interval, count_interval_a, count_interval_b;

    //! 時間計測の為の変数
    public float time;

    /** -----------------------------------------------------------
    *  @fn      UpDate
    * @brief  本クラスのコンポーネントの更新時にシステムから呼ばれる
    * 
    -------------------------------------------------------------*/
    protected override void Update()
    {
        time += Time.deltaTime * 1000;

        //! ボタンが押され続けているときの処理
        if (push)
        {
            count_time_a = time;
            count_time = count_time_a - count_time_b;
        }

        //! テキスト表記の更新
        Write(count_push, count_time,count_interval);
    }


    /** -----------------------------------------------------------
     * @fn      OnClick
     * @brief   各ボタンを押された際の処理
     * @detail  if文ごとにボタンの処理を記載している。
     * 
     -------------------------------------------------------------*/
    protected override void OnClick(string objectName)
    {
        //! メインボタンの処理
        if ("Button".Equals(objectName))
        {
            //! プッシュ回数の処理
            count_push += 1;

            //! インターバール時間の処理
            count_interval_b = time;
            count_interval = count_interval_b - count_interval_a;
            count_interval_a = count_interval_b;
        }

        //! リセットボタンの処理
        if ("Reset".Equals(objectName))
        {
            count_push = 0;
            time = 0;
        }
    }

    /** --------------------------------------------------
    *  @fn      Write
    *  @param[in]   push        ボタンを押した回数
    *  @param[in]   time        ボタンを長押ししている間の時間
    *  @param[in]   interval    ボタンを押してから次に押されるまでの時間
    *  @brief   テキスト更新
    *  
    -------------------------------------------------- */
    public void Write(int push, float time, float interval)
    {
        tex_push.text = "PushCount:" + push;
        tex_time.text = "PressTime:" + count_time.ToString("F2") + "ms";
        tex_interval.text = "TapInterval:" + interval.ToString("F2") + "ms";
    }

    /** --------------------------------------------------
    *  @fn      PushDown
    *  @brief   ボタンを押した状態の時の処理
    *  
    -------------------------------------------------- */
    public void PushDown()
    {
        push = true;
    }

    /** --------------------------------------------------
    *  @fn      PushUp
    *  @brief   ボタンから離れた状態の時の処理
    *  
    -------------------------------------------------- */
    public void PushUp()
    {
        push = false;
        count_time_b = time;
    }
}
