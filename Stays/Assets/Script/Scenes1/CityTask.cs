using UnityEngine;
/// <summary>
/// 20220807���d1 ���ȧP�w
/// </summary>
public class CityTask : MonoBehaviour
{
    #region ���
    [Header("A_�e�H")]
    private int a_condition=2;
    public int a_done=0;
    public bool a_finish = false;
    [Header("B_������")]
    public bool b_towerDialogue;
    private S1_Tower tower;
    [Header("C_�~���H")]
    public bool c_trust;
    private S1_Trust trust;
    [Header("�i�J����")]
    public bool trainStation;
    public area area22;
    [Header("D_�M���")]
    public bool d_cleaning;
    S1_CleaningStaff cleaningStaff;
    #endregion
    private void Start()
    {
        tower = GameObject.Find("����").GetComponent<S1_Tower>();
        trust = GameObject.Find("�~���H").GetComponent<S1_Trust>();
        cleaningStaff= GameObject.Find("�M���").GetComponent<S1_CleaningStaff>();

    }
    private void FixedUpdate()
    {
        A_Judge();
        B_Tower();
        C_Trust();
        InStation();
        d_cleaning = cleaningStaff.cleanerAway;
    }
    #region ��k
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
