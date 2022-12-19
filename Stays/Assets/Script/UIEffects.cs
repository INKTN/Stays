using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// UI特效20221218
/// </summary>
public class UIEffects : MonoBehaviour
{
   #region 欄位
    public enum type {
        flashing,
        ch 
    };
    public type typeSelect;//模式
    [Header("時間"),Range(0,20)]
    public float timer;//速度
    [Header("閃爍用")]
    public Image image;//要套用特效目標
    [Header("最低亮度"),Range(0,1)]
    public float brightness = 0;
    #endregion
    private void Start()
    {
        if (typeSelect == type.flashing)
        {
           
            InvokeRepeating("Flash", 0.1f,timer*3);
            InvokeRepeating("ReFlash", timer, timer);
            // countdown = timer;
        }
    }
    #region 方法
    void Flash()
    {
        image.CrossFadeAlpha(brightness, timer/2, false);
        //print("比耶消失");

    }
    void ReFlash()
    {
        image.CrossFadeAlpha(1, timer/2, false);
       // print("出現");
    }
    #endregion
}
