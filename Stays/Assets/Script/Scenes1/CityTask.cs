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

    #endregion
    private void FixedUpdate()
    {
        A_Judge();
    }
    #region ��k
    private void A_Judge()
    {
        if (a_done == a_condition) a_finish = true;
    }
    #endregion
}
