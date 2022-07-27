using UnityEngine;

/// <summary>
/// 20220119判斷任務
/// 20220606 關卡五判斷任務
/// </summary>
public class TaskListGoHome : MonoBehaviour
{
    #region 欄位
    [Header("A_漂流物")]
    public bool a_wood;
    [Header("B_橋")]
    private Bridge b_bridge;
    public bool b_BridgeFin;
    [Header("C_NPC小孩")]
    private Kid C_kidC;
    public bool c_Kid;
    [Header("All Fin")]
    public bool allFin;
    #endregion
    private void Start()
    {
        //A_Cow = GameObject.Find("CowBlW").GetComponent<Animal>();範例
        //A_Sheep = GameObject.Find("SheepWhite").GetComponent<Animal>();
        b_bridge = GameObject.Find("橋").GetComponent<Bridge>();
        C_kidC = GameObject.Find("Kid").GetComponent<Kid>();
    }
    private void Update()
    {
        fin();
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
    private void fin()
    {
        b_BridgeFin = b_bridge.skillUse;
        c_Kid= C_kidC.daloguesTaskFin;

        if (b_BridgeFin && c_Kid)
        {
            allFin = true;
        }
    }
    #endregion
}
