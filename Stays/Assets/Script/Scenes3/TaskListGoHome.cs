using UnityEngine;

/// <summary>
/// 20220119判斷任務
/// 20220606 關卡五判斷任務
/// </summary>
public class TaskListGoHome : MonoBehaviour
{
    #region 欄位
    [Header("A_橋")]
    private Bridge a_bridge;
    [Header("B_NPC小孩")]
    private Kid b_kid;
    
    #endregion
    private void Start()
    {
        #region A
        //A_Cow = GameObject.Find("CowBlW").GetComponent<Animal>();範例
        //A_Sheep = GameObject.Find("SheepWhite").GetComponent<Animal>();
        a_bridge = GameObject.Find("橋").GetComponent<Bridge>();
        b_kid = GameObject.Find("Kid").GetComponent<Kid>();
        #endregion
    }
    void Update()
    {
        // A_AnimalStop();
    }
    #region 方法
     /// <summary>
     /// 當動物A組速度相同 則bool為達成TRUE並回傳相對C#資訊
     /// </summary>
     //private void A_AnimalStop()
     //{
     //if (A_Cow.speed == A_Sheep.speed)
     //  {
     //     A_Sheep.solving = true;
     //      A_Cow.solving = true;
     //   }
     //else
     //  {
     //   A_Sheep.solving = false;
     //A_Cow.solving = false;
     //   }
     public bool A_BridgeFin()//20220704橋完成判定
     {
        return a_bridge.skillUse;
     }
    public bool B_Kid()//20220706小孩完成判定
    {
        return b_kid.daloguesTaskFin;
    }
    #endregion
}
