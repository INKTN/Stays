using UnityEngine;

public class S1_Start : MonoBehaviour
{
    #region ���
    [Header("��ܸ��")]
    public DataDalogue[] dataDalogues;

    [Header("��ܨt��")]
    public DialongueSystem dialongueSystem;
    [Header("�@������")]
    public bool playdone0;
    [Header("�ϰ�")]
    public area area;

    #endregion
    private void Start()
    {
        area = gameObject.transform.GetChild(0).GetComponent<area>();
    }
    private void FixedUpdate()
    {
        Detection();

    }
    #region ��k
    private void Detection()
    {
        if (area.chIn && !playdone0)
        {
            dialongueSystem.StartDialogue(dataDalogues[0].conversationContent);//��ܸ��Ū��
            dialongueSystem.NameEnter(dataDalogues[0].talkName);
            playdone0 = true;
        }

    }
    #endregion
}
