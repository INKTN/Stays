using UnityEngine;
/// <summary>
/// 家門前20220720
/// </summary>

public class S3_End : MonoBehaviour
{
    #region 欄位
    [Header("任務判定")]
    private TaskListGoHome task;
    [Header("對話資料")]
    public DataDalogue[] dataDalogues;

    [Header("對話系統")]
    public DialongueSystem dialongueSystem;
    [Header("區域")]
    public area area;
    public bool read;
    public bool finRead;
    #endregion
    private void Start()
    {
        task= GameObject.Find("System").GetComponent<TaskListGoHome>();
        area = gameObject.transform.GetChild(0).GetComponent<area>();
    }
    private void FixedUpdate()
    {
        Detection();
        if (!area.chIn) read = false;
    }
    #region 方法
    private void Detection()
    {
            if (area.chIn&&task.allFin&&!finRead)
            {
                dialongueSystem.StartDialogue(dataDalogues[0].conversationContent);//對話資料讀取
                dialongueSystem.NameEnter(dataDalogues[0].talkName);
            finRead = true;
            }
            else if (area.chIn&&!read)
            {
                dialongueSystem.StartDialogue(dataDalogues[1].conversationContent);//對話資料讀取
                dialongueSystem.NameEnter(dataDalogues[1].talkName);
            read = true;
            }
        
    }
    #endregion
}
