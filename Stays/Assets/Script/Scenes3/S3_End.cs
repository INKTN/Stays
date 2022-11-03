using System.Collections;
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
    public bool finRead;
    [Header("����"), Range(0, 1)]
    public float interval = 0.1f;
    #endregion
    private void Start()
    {
        task= GameObject.Find("System").GetComponent<TaskListGoHome>();
        area = gameObject.transform.GetChild(0).GetComponent<area>();
    }
    private void Update()
    {
        StartCoroutine(Detection());
        if (!area.chIn) read = false;
    }
    #region ��k
    private IEnumerator Detection()
    {
        yield return new WaitForSeconds(interval); //����(interval)��
        if (area.chIn&&task.allFin&&!finRead)
        {
                finRead = true;
                dialongueSystem.StartDialogue(dataDalogues[0].conversationContent);//��ܸ��Ū��
                dialongueSystem.NameEnter(dataDalogues[0].talkName);
        }
            else if (area.chIn&&!read&&!finRead)
            {
                read = true;
                dialongueSystem.StartDialogue(dataDalogues[1].conversationContent);//��ܸ��Ū��
                dialongueSystem.NameEnter(dataDalogues[1].talkName);
            }
        
    }
    #endregion
}
