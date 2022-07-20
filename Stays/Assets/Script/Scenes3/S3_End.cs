using UnityEngine;
/// <summary>
/// 家門前20220720
/// </summary>

public class S3_End : MonoBehaviour
{
    #region 欄位
    [Header("任務判定")]
    private TaskListGoHome task;
    [Header("玩家")]
    private PlayerCharacter player;
    #endregion
    private void Start()
    {
        task= GameObject.Find("System").GetComponent<TaskListGoHome>();
    }
    #region 方法
    private void Detection()
    {
        if (task.allFin)
        {

        }
    }
    #endregion
}
