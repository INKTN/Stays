using UnityEngine;
/// <summary>
/// �e�H���� 20220807
/// </summary>
public class S1_SendLetter : MonoBehaviour
{
    #region ���
    [Header("���ȧP�w")]
    private CityTask task;
    [Header("��ܸ��")]
    public DataDalogue[] dataDalogues;

    [Header("��ܨt��")]
    public DialongueSystem dialongueSystem;
    [Header("�ϰ�")]
    public area area;
    public bool finRead;
    [Header("�D��")]
    private PlayerCharacter player;
    #endregion
    private void Start()
    {
        task = GameObject.Find("System").GetComponent<CityTask>();
        dialongueSystem= GameObject.Find("System").GetComponent<DialongueSystem>();
        area = gameObject.transform.GetChild(0).GetComponent<area>();
        player = GameObject.Find("�D��").GetComponent<PlayerCharacter>();
    }
    private void FixedUpdate()
    {
        Detection();
        
    }
    #region ��k
    private void Detection()
    {
        if (area.chIn && !finRead &&!player.walking)
        {
            dialongueSystem.StartDialogue(dataDalogues[0].conversationContent);//��ܸ��Ū��
            dialongueSystem.NameEnter(dataDalogues[0].talkName);
            finRead = true;
            task.a_done++;
        }

    }
    #endregion
}
