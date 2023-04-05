using UnityEngine;
/// <summary>
/// 20220807關卡1 任務判定
/// </summary>
public class CityTask : MonoBehaviour
{
    #region 欄位
    [Header("A_送信")]
    private int a_condition=2;
    public int a_done=0;
    public bool a_finish = false;
    [Header("B_鐘塔對話")]
    public bool b_towerDialogue;
    private S1_Tower tower;
    [Header("C_年輕人")]
    public bool c_trust;
    private S1_Trust trust;
    [Header("進入車站")]
    public bool trainStation;
    public area area22;
    [Header("D_清潔員")]
    public bool d_cleaning;
    S1_CleaningStaff cleaningStaff;
    [Header("E_火車前對話")]
    public bool e_trin;
    private S1_Completed completed;
    public bool fin;

    #endregion
    private void Start()
    {
        tower = GameObject.Find("鐘塔").GetComponent<S1_Tower>();
        trust = GameObject.Find("年輕人").GetComponent<S1_Trust>();
        cleaningStaff= GameObject.Find("清潔員").GetComponent<S1_CleaningStaff>();
        completed= GameObject.Find("火車").GetComponent<S1_Completed>();
    }

    private void Update()
    {
        A_Judge();
        B_Tower();
        C_Trust();
        InStation();
        d_cleaning = cleaningStaff.cleanerAway;
        e_trin = completed.playdone1;
        if (a_finish && b_towerDialogue && c_trust && d_cleaning&&e_trin)
        {

            fin=true;
        }
        else fin=false;
    }
    
    #region 方法
    private void A_Judge()
    {
        if (a_done == a_condition) a_finish = true;
    }
    private void B_Tower()
    {
        b_towerDialogue = tower.moveGo;
    }
    private void C_Trust()
    {
        c_trust = trust.playdone1;
    }
    public void InStation()
    {
        if (!trainStation && area22.chIn)
        {
            trainStation = true;
        }
        
    }

    #endregion
}
