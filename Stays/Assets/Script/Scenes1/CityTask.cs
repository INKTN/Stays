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
    #endregion
    private void Start()
    {
        tower = GameObject.Find("鐘塔").GetComponent<S1_Tower>();
        trust = GameObject.Find("年輕人").GetComponent<S1_Trust>();
        
    }
    private void FixedUpdate()
    {
        A_Judge();
        B_Tower();
        C_Trust();
        InStation();
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
        c_trust = trust.playdone0;
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
