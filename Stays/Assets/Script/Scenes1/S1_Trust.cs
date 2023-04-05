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
    private float speed = 10;
    public Transform target;
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
    private void Update()
    {
        if (task.b_towerDialogue && (!playdone0||post.transform.position!=target.transform.position) && area.chIn && !dialongueSystem.display)
        {
            NPCGo();
        }
        if (!playdone1 && playdone0 && !dialongueSystem.display)
        {
            playdone1 = true;
            StartCoroutine(Confirm());
        }

        if (playdone1 && playdone0 && !dialongueSystem.display)
            t.switches = false;//�}Ĳ��
    }
    private IEnumerator Meet()
    {
        t.switches = true;//��Ĳ��
        NPCGo();
        yield return new WaitForSeconds(2);
        
        
    }
    private IEnumerator Confirm()
    {
        playdone1 = true;
        t.switches = true;//��Ĳ��
        yield return new WaitForSeconds(2);
        player.transform.LookAt(post.transform);
        this.transform.LookAt(player.transform);
        dialongueSystem.StopAllCoroutines();
        dialongueSystem.StartDialogue(dataDalogues[0].conversationContent);//��ܸ��Ū��
        dialongueSystem.NameEnter(dataDalogues[0].talkName);

    }
    private void NPCGo()
    {
        print("����");
        this.transform.LookAt(player.transform);
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        playdone0 = true;
    }
    #endregion
}
