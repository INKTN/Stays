using System.Collections;
using UnityEngine;
/// <summary>
/// ���H�����
/// </summary>

public class S1_Trust : MonoBehaviour
{
    #region ���
    [Header("��ܸ��")]
    public DataDalogue[] dataDalogues;
    [Header("��ܨt��")]
    private DialongueSystem dialongueSystem;
    [Header("Ĳ�o�ϰ�")]
    public area area;
    [Header("���Ȱ���")]
    private CityTask task;
    [Header("Ĳ���}��")]
    private TouchS t;
    [Header("����")]
    private PlayerCharacter player;
    [Header("�}��")]
    public bool playdone0;
    public bool playdone1;
    [Header("��m")]
    public GameObject post;
    #endregion
    private void Start()
    {
        post = this.gameObject;
        task = GameObject.Find("System").GetComponent<CityTask>();
        dialongueSystem = GameObject.Find("System").GetComponent<DialongueSystem>();
        t = GameObject.Find("System").GetComponent<TouchS>();
        player = GameObject.Find("�D��").GetComponent<PlayerCharacter>();
    }
    #region ��k
    private void FixedUpdate()
    {
        if (task.b_towerDialogue && !playdone0 && area.chIn && !dialongueSystem.display)
        {
            StartCoroutine(Meet());
        }
        if(!playdone1 && playdone0 && !dialongueSystem.display)
        {
            StartCoroutine(Confirm());
        }
        if (playdone1 && playdone0 && !dialongueSystem.display)
            t.switches = false;//�}Ĳ��
    }
    private IEnumerator Meet()
    {
        t.switches = true;//��Ĳ��
        yield return new WaitForSeconds(2);
        player.transform.LookAt(post.transform);
        dialongueSystem.StopAllCoroutines();
        dialongueSystem.StartDialogue(dataDalogues[0].conversationContent);//��ܸ��Ū��
        dialongueSystem.NameEnter(dataDalogues[0].talkName);
        playdone0 = true;
        
    }
    private IEnumerator Confirm()
    {
        t.switches = true;//��Ĳ��
        yield return new WaitForSeconds(2);
        player.transform.LookAt(post.transform);
        dialongueSystem.StopAllCoroutines();
        dialongueSystem.StartDialogue(dataDalogues[1].conversationContent);//��ܸ��Ū��
        dialongueSystem.NameEnter(dataDalogues[1].talkName);
        playdone1 = true;

    }
    #endregion
}
