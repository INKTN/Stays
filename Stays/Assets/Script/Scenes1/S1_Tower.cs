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
    public bool playdone4;
    public bool playdone5;
    [Header("�����ǰe")]
    public string finPin;
    private PlayerCharacter player;
    public GameObject target;
    public Collider station;

    #endregion
    private void Start()
    {
        task = GameObject.Find("System").GetComponent<CityTask>();
        dialongueSystem = GameObject.Find("System").GetComponent<DialongueSystem>();
        t= GameObject.Find("System").GetComponent<TouchS>();
        cameratest = cameraControl.GetComponent<Cameratest>();
        s1_ManipulationNPC = npc.GetComponent<S1_ManipulationNPC>();
        player = GameObject.Find("�D��").GetComponent<PlayerCharacter>();
        
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
            dialongueSystem.StopAllCoroutines();
            StartCoroutine(Performance());
        }
        else if (playdone0 && !dialongueSystem.display && !playdone1)
        { FocusTower(); }
        else if(!playdone2 && !dialongueSystem.display && playdone1)
        {
            dialongueSystem.StopAllCoroutines();
            StartCoroutine(FocusNPC()); 
        }
        //if (playdone2 && !dialongueSystem.display && !playdone3) { StartCoroutine(TalkTower()); }
        else if(playdone3 && !dialongueSystem.display && !playdone4) 
        {
            dialongueSystem.StopAllCoroutines();
            StartCoroutine(TowerEnd()); 
        }
        else if(playdone4 && !dialongueSystem.display && !playdone5) 
        {
            dialongueSystem.StopAllCoroutines();
            StartCoroutine(GoStation()); 
        }
        else if (playdone4 && !dialongueSystem.display && playdone5 )
        {
            MoveTo();
        }
    }
    private IEnumerator Performance()
    {
        cameratest.switches = true;//�����Y����
        t.switches = true;//��Ĳ��
        print("��X:"+0);
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
        print("��X:" + 1);
        dialongueSystem.StopAllCoroutines();
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
        print("��X:" + 2);
        yield return new WaitForSeconds(3);
        s1_ManipulationNPC.speed = 0.8f;
        dialongueSystem.StopAllCoroutines();
        dialongueSystem.StartDialogue(dataDalogues[2].conversationContent);//��ܸ��Ū��
        dialongueSystem.NameEnter(dataDalogues[2].talkName);
         StartCoroutine(TalkTower());
    }
    private IEnumerator TalkTower()
    {
        cameratest.switches = true; cameratest.caTask = false;//�����Y����
        t.switches = true;//��Ĳ��
        camera_Tower.enabled = true;//���Y����
        camera_NPC.enabled = false;
        yield return new WaitForSeconds(2);
        print("��X:" + 3);
        dialongueSystem.StopAllCoroutines();
        dialongueSystem.StartDialogue(dataDalogues[3].conversationContent);//��ܸ��Ū��
        dialongueSystem.NameEnter(dataDalogues[3].talkName);
        playdone3 = true;
    }
    private IEnumerator TowerEnd()
    {
        playdone4 = true;
        cameratest.switches = false; cameratest.caTask = true;//�����Y����
        t.switches = false;//��Ĳ��
        cameraControl.enabled = true;//���Y����
        camera_Tower.enabled = false;
        print("��X:" + 4);
       //�o��
        yield return new WaitForSeconds(0.5F);
        dialongueSystem.StopAllCoroutines();
        dialongueSystem.StartDialogue(dataDalogues[4].conversationContent);//��ܸ��Ū�� 
        dialongueSystem.NameEnter(dataDalogues[4].talkName);

    }
    private IEnumerator GoStation()
    {
        playdone5 = true;
        cameratest.switches = false; cameratest.caTask = true;//�����Y����
        t.switches = false;//��Ĳ��
        cameraControl.enabled = true;//���Y����
        camera_Tower.enabled = false;
        print("��X:" + 5);
        dialongueSystem.StopAllCoroutines();
        dialongueSystem.StartDialogue(dataDalogues[5].conversationContent);//��ܸ��Ū��
        dialongueSystem.NameEnter(dataDalogues[5].talkName);
        station.isTrigger = true;
        yield return new WaitForSeconds(0.5F);
        //print(player.transform.position);

    }
    private void MoveTo()
    {
        Transform fin = GameObject.Find(finPin).transform;
        player.speed = 12;
        player.Move(fin);
        print(fin.name+fin);
    }
        #endregion
}
