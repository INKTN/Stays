using UnityEngine;
using System.Collections;
/// <summary>
/// 20220119�P�_����
/// 20220606 ���d���P�_����
/// </summary>
public class TaskListGoHome : MonoBehaviour
{
    #region ���
    [Header("A_��")]
    private Bridge a_bridge;
    #endregion
    private void Start()
    {
        #region A
        //A_Cow = GameObject.Find("CowBlW").GetComponent<Animal>();�d��
        //A_Sheep = GameObject.Find("SheepWhite").GetComponent<Animal>();
        a_bridge = GameObject.Find("��").GetComponent<Bridge>();
        #endregion
    }
    void Update()
    {
        // A_AnimalStop();

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
    #endregion
}
