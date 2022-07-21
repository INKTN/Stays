using UnityEngine;
/// <summary>
/// �a���e20220720
/// </summary>

public class S3_End : MonoBehaviour
{
    #region ���
    [Header("���ȧP�w")]
    private TaskListGoHome task;
    [Header("��ܸ��")]
    public DataDalogue[] dataDalogues;

    [Header("��ܨt��")]
    public DialongueSystem dialongueSystem;
    [Header("�ϰ�")]
    public area area;
    public bool read;
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
    #region ��k
    private void Detection()
    {
        if (area.chIn&&!read)
        {
            if (task.allFin)
            {
                dialongueSystem.StartDialogue(dataDalogues[0].conversationContent);//��ܸ��Ū��
                dialongueSystem.NameEnter(dataDalogues[0].talkName);
            }
            else
            {
                dialongueSystem.StartDialogue(dataDalogues[1].conversationContent);//��ܸ��Ū��
                dialongueSystem.NameEnter(dataDalogues[1].talkName);
            }
            read = true;
        }
    }
    #endregion
}
