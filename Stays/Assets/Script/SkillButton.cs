using UnityEngine.UI;
using UnityEngine;
/// <summary>
/// 技能按鈕
/// 20220418 變換速度(改為增加減少)
/// </summary>

public class SkillButton : MonoBehaviour
{
    #region 欄位
    
    [Header("速度值"), Range(-20, 20)]
    public float speed;
    //UI控制器的開關
    private UIManager skillOpen;
    //觸碰項目
    public Transform Target;
  
    #endregion
    private void Awake()
    {
        //喚醒時取得UI控制器與選擇物件
        skillOpen = GameObject.Find("System").GetComponent<UIManager>();
        Target = skillOpen.touchObject;
       
    }
    
    public void SkillFast()
    {
        if(Target.tag=="animal")
        {
           var animal = Target.GetComponent<Animal>();//如果碰到的東西TAG為動物，取得動物腳本
            animal.SkillUse(speed);//呼叫動物改變速度的方法
        }

        if (Target.tag == "obstacle")//2022043
        {
           var tree = Target.GetComponent<TreeVariation>();//如果碰到的東西TAG為樹，取得動物腳本
            tree.SkillUse(speed);//呼叫樹改變速度的方法
        }
        //print("使用技能" + speed);
        skillOpen.skillOpen = false;//關閉UI控制中顯示開關
        Destroy(GameObject.Find("skill UI(Clone)"));//刪除SkillUI
    }
}
