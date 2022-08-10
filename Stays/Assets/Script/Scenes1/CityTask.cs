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

    #endregion
    private void FixedUpdate()
    {
        A_Judge();
    }
    #region 方法
    private void A_Judge()
    {
        if (a_done == a_condition) a_finish = true;
    }
    #endregion
}
