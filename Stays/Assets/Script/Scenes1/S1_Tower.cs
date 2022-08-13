using UnityEngine;
using System.Collections;
/// <summary>
/// ����@��20220810
/// </summary>
public class S1_Tower : MonoBehaviour
{
    #region ���
    [Header("��ܸ��")]
    public DataDalogue[] dataDalogues;
    [Header("��ܨt��")]
    public DialongueSystem dialongueSystem;

    [Header("Ĳ�o�ϰ�")]
    public area area;
    [Header("���Ȱ���")]
    private CityTask task;
    [Header("Ĳ���}��")]
    private TouchS t;
    [Header("��v��")]
    public Camera cameraControl;
    private Cameratest cameratest;
    public Camera camera_Tower;
    public Camera camera_NPC;
    //public Vector3[] pot;
    [Header("NPC")]
    public GameObject npc;
    public float speed = 1;
    private S1_ManipulationNPC s1_ManipulationNPC;
    [Header("�}��")]
    public bool playdone0;
    public bool playdone1;
    public bool playdone2;
    public bool playdone3;
    #endregion
    private void Start()
    {
        task = GameObject.Find("System").GetComponent<CityTask>();
        dialongueSystem = GameObject.Find("System").GetComponent<DialongueSystem>();
        t= GameObject.Find("System").GetComponent<TouchS>();
        cameratest = cameraControl.GetComponent<Cameratest>();
        s1_ManipulationNPC = npc.GetComponent<S1_ManipulationNPC>();
    }
    private void FixedUpdate()
    {
        Plot();
        StartDialogue();
    }
    #region ��k
    private void Plot()
    {
        if (task.a_finish && !playdone0 && area.chIn)
        {
            dialongueSystem.StartDialogue(dataDalogues[0].conversationContent);//��ܸ��Ū��
            dialongueSystem.NameEnter(dataDalogues[0].talkName);
            playdone0 = true;
        }
    }
    public void StartDialogue()
    {
        if (task.a_finish && !playdone0 && area.chIn)
        {
            StartCoroutine(Performance());
        }
        if (playdone0 && !dialongueSystem.display && !playdone1)
        { FocusTower(); }
        if (!playdone2 && !dialongueSystem.display && playdone1)
        { StartCoroutine(FocusNPC()); }
    if(playdone2&& !dialongueSystem.display&&!playdone3) StartCoroutine(TalkTower());
    }
    private IEnumerator Performance()
    {
        cameratest.switches = true;//�����Y����
        t.switches = true;//��Ĳ��
        //����ʵe
        yield return new WaitForSeconds(5);
        dialongueSystem.StartDialogue(dataDalogues[0].conversationContent);//��ܸ��Ū��
        dialongueSystem.NameEnter(dataDalogues[0].talkName);
        playdone0 = true;   
    }
    private void FocusTower()
    {
        camera_Tower.enabled = true;
        cameraControl.enabled=false;//���Y����
        cameratest.switches = true; cameratest.caTask = false;//�����Y����
        //yield return new WaitForSeconds(1);
        dialongueSystem.StartDialogue(dataDalogues[1].conversationContent);//��ܸ��Ū��
        dialongueSystem.NameEnter(dataDalogues[1].talkName);
        playdone1 = true;
    }
    private IEnumerator FocusNPC()
    {
        playdone2 = true;
        cameratest.switches = true;cameratest.caTask = false;//�����Y����
        t.switches = true;//��Ĳ��
        camera_NPC.enabled = true;
        camera_Tower.enabled = false;//���Y����
        s1_ManipulationNPC.Normal();//NPC����
        yield return new WaitForSeconds(2);
        s1_ManipulationNPC.speed = 0.8f;
        dialongueSystem.StartDialogue(dataDalogues[2].conversationContent);//��ܸ��Ū��
        dialongueSystem.NameEnter(dataDalogues[2].talkName);
    }
    private IEnumerator TalkTower()
    {
        playdone3 = true;
        cameratest.switches = true; cameratest.caTask = false;//�����Y����
        t.switches = true;//��Ĳ��
        camera_Tower.enabled = true;//���Y����
        camera_NPC.enabled = false;
        yield return new WaitForSeconds(2);
        dialongueSystem.StartDialogue(dataDalogues[3].conversationContent);//��ܸ��Ū��
        dialongueSystem.NameEnter(dataDalogues[3].talkName);
    }
    private void TowerEnd()
    {
        cameratest.switches = false; cameratest.caTask = true;//�����Y����
        t.switches = false;//��Ĳ��
        cameraControl.enabled = true;//���Y����
        camera_Tower.enabled = false;
    }
    #endregion
}
