using UnityEngine;

/// <summary>
/// 20220119�P�_����
/// 20220606 ���d���P�_����
/// </summary>
public class TaskListGoHome : MonoBehaviour
{
    #region ���
    [Header("A_��")]
    private Bridge a_bridge;
    public bool A_BridgeFin;
    [Header("B_NPC�p��")]
    private Kid b_kid;
    public bool B_Kid;
    [Header("All Fin")]
    public bool allFin;
    #endregion
    private void Start()
    {
        //A_Cow = GameObject.Find("CowBlW").GetComponent<Animal>();�d��
        //A_Sheep = GameObject.Find("SheepWhite").GetComponent<Animal>();
        a_bridge = GameObject.Find("��").GetComponent<Bridge>();
        b_kid = GameObject.Find("Kid").GetComponent<Kid>();
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
        A_BridgeFin = a_bridge.skillUse;
        B_Kid= b_kid.daloguesTaskFin;

        if (A_BridgeFin && B_Kid)
        {
            allFin = true;
        }
    }
    #endregion
}
