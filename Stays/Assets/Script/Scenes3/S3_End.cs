using UnityEngine;
/// <summary>
/// �a���e20220720
/// </summary>

public class S3_End : MonoBehaviour
{
    #region ���
    [Header("���ȧP�w")]
    private TaskListGoHome task;
    [Header("���a")]
    private PlayerCharacter player;
    #endregion
    private void Start()
    {
        task= GameObject.Find("System").GetComponent<TaskListGoHome>();
    }
    #region ��k
    private void Detection()
    {
        if (task.allFin)
        {

        }
    }
    #endregion
}
