using UnityEngine;
using System.Collections;
/// <summary>
/// �p��NPC�}��20220701
/// </summary>

public class Kid : MonoBehaviour
{
    #region ���
    [Header("�ʵe���")]
    private Animator an;
    [Header("��ܸ��")]
    public DataDalogue[] dataDalogues;//��ܨt��
    [Header("�U���P�w")]
    public bool dalogues1Fin;//���Ĥ@������
    public bool childGrowth;//�ϥΧޯ�
    public bool dalogues2Fin;
    public bool daloguesTaskFin;//���ȧ������

    [Header("��ܨt��")]
    private DialongueSystem dialongueSystem;
    [Header("Ĳ�o��H")]
    public string target = "�D��";
    [Header("���Y�O�_���E�J")]
    public bool ch;
    [Header("��L�}��")]
    private Cameratest cameratest;
    [Header("��������")]
    public GameObject taskTa;//��
    private S3_Tree tree;
    public Camera setCamera;
    public Camera oriCamera;
    public GameObject initial;//�p�ļҫ�
    public GameObject adultModels;//���~�H�ҫ�
    public bool tastBool;
    [Header("�����d��")]
    public Vector3 detectionRange = Vector3.one;
    public Vector3 detectionHight;
    [Header("Ĳ�I�d�����")]
    public bool gizmosOn;
    private UIManager skillUI;
    //private Cameratest cameratest;
    [Header("�ޯ�ϥ�")]
    public float speed = 1;
    public bool man;


    #endregion
    private void Start()
    {
        an = GetComponent<Animator>();
        dialongueSystem = GameObject.Find("System").GetComponent<DialongueSystem>();
        oriCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
        skillUI = GameObject.Find("System").GetComponent<UIManager>();
        cameratest = GameObject.Find("MainCamera").GetComponent<Cameratest>();
        tree = taskTa.GetComponent<S3_Tree>();
    }
    private void FixedUpdate()
    {
        if (!childGrowth && speed == 2)//�ϥΧޯ��
        {
            childGrowth = true;
            StartCoroutine(ChangePtion());
        }
    }
    private void OnDrawGizmos()
    {
        if (gizmosOn)
        {
            Gizmos.color = new Color(1, 0, 0, .5f);//�P�_�ϳ]�m������
            Gizmos.DrawCube(transform.position + detectionHight, detectionRange);//�����Ϧ�m
        }
    }//��m�������
  
    #region ��k
    public void Check()//�˴������O�_���F��éI�s���
    {
        ///print("�����^��");
        Collider[] hit = Physics.OverlapBox(transform.position + detectionHight, detectionRange / 2, Quaternion.identity);//(�����I�A�j�p�A����A�ϼh�X)
        int i = 0;
        transform.LookAt(GameObject.Find("�D��").transform);
        while (i < hit.Length)//�Yi�p��hit�̤j��
        {
            //print(hit[i].name);
            //Contains:�b�r�ꤤ�M��A�Y���^��True
            #region ���
            if (hit[i].name.Contains(target)) 
            {
                if (!dalogues1Fin)
                {
                    dialongueSystem.StopAllCoroutines();
                    dialongueSystem.StartDialogue(dataDalogues[0].conversationContent);//��ܸ��Ū��
                    dialongueSystem.NameEnter(dataDalogues[0].talkName);
                    dalogues1Fin = true;
                    
                }
                else if(dalogues1Fin&& !dialongueSystem.display&& !childGrowth&&speed!=2)
                {
                    setCamera.transform.position = new Vector3(27, 8, 56);
                    transform.LookAt(setCamera.transform);
                    Skill();
                }
                else if(!dalogues2Fin&&!dialongueSystem.display&& childGrowth)
                {
                    dialongueSystem.StopAllCoroutines();
                    dialongueSystem.StartDialogue(dataDalogues[1].conversationContent);//��ܸ��Ū��
                    dialongueSystem.NameEnter(dataDalogues[1].talkName);
                    dalogues2Fin = true;
                }
                else if (!dialongueSystem.display &&tree.taskFin)
                {
                    dialongueSystem.StopAllCoroutines();
                    dialongueSystem.StartDialogue(dataDalogues[2].conversationContent);//��ܸ��Ū��
                    dialongueSystem.NameEnter(dataDalogues[2].talkName);
                }

            }
            #endregion
            i++;
        }
    }

    public void Skill()
    {
        ch = !ch;
        setCamera.enabled = ch;
        oriCamera.enabled = !ch;
        cameratest.caTask = false;
        skillUI.SkillOn(transform);//�}��SKILLUI
 
    }
    public void SkillUse(float get)//��o�ޯ���s���ƭ�
    {
        ch = !ch;
        setCamera.enabled = false;
        oriCamera.enabled = true;
        cameratest.caTask = true;
        speed += get;
        //print("�p�ĥ[�t");
       
    }
    private IEnumerator ChangePtion()//��{��ܼҫ���1��
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.transform.localScale = new Vector3(1, 1, 1);//��j�ҫ�
        yield return new WaitForSeconds(0.2f);
        adultModels.SetActive(true);//�}�Ҧ��~�H�ҫ����
        initial.SetActive (false);//�����p�ļҫ����

    }
    #endregion
}
