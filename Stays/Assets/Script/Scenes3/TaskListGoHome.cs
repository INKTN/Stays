using UnityEngine;

/// <summary>
/// 20220119�P�_����
/// 20220606 ���d���P�_����
/// </summary>
public class TaskListGoHome : MonoBehaviour
{
    #region ���
    [Header("A_�}�y��")]
    public bool a_wood;
    [Header("B_��")]
    private Bridge b_bridge;
    public bool b_BridgeFin;
    [Header("C_NPC�p��")]
    private Kid C_kidC;
    public bool c_Kid;
    [Header("All Fin")]
    public bool allFin;
    #endregion
    private void Start()
    {
        //A_Cow = GameObject.Find("CowBlW").GetComponent<Animal>();�d��
        //A_Sheep = GameObject.Find("SheepWhite").GetComponent<Animal>();
        b_bridge = GameObject.Find("��").GetComponent<Bridge>();
        C_kidC = GameObject.Find("Kid").GetComponent<Kid>();
    }
    private void Update()
    {
        fin();
    }
    #region ��k
    /// <summary>
    /// ��ʪ�A�ճt�׬ۦP �hbool���F��TRUE�æ^�Ǭ۹�C#��T
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
