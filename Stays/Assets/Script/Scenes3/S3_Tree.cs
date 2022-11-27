using UnityEngine;
using System.Collections;
public class S3_Tree : MonoBehaviour
{
    #region ���
    [Header("��v��")]
    public Camera setCamera;
    public Camera oriCamera;
    [Header("���Y�O�_���E�J")]
    public bool ch;
    [Header("��L�}��")]
    private Cameratest cameratest;
    private Kid kid;
    [Header("Ĳ��")]
    private float begainTime = 0f;//�̪��I���ɶ�
    private Vector2 startPos = Vector2.zero;//Ĳ�I�_�l�I
    public float quickDoubleTabInterval = 0.15f;
    public float lastTouchTime;//�W�@���I����}���ɶ�
    //public string debugInfo = "Nothing";
    public string target;
    private static float intervals;//���j�ɶ�
    private static Touch lastTouch;//�ثe�S�Ψ�A���G�D�n�O�O���W�@����Ĳ�I
    [Header("�ޯ�t��")]
    private UIManager skillUI;
    [Header("�i�_�ϥΧޯ�")]
    public bool canSkill;
    [Header("�ޯ�t��")]
    public float speed = 1;
    private float objectiveSpeed = 2;
    [Header("���ȧ���")]
    public bool task1;
    public bool taskFin = false;
    [Header("��ܨt��")]
    private DialongueSystem dialongueSystem;
    [Header("��ܸ��")]
    public DataDalogue[] dataDalogues;//��ܨt��
    public bool dalogues1Fin;
    #endregion

    private void Start()
    {
        #region ��v��
        oriCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
        setCamera = GameObject.Find("TreeCa").GetComponent<Camera>();
        #endregion
        #region �}��
        cameratest = GameObject.Find("MainCamera").GetComponent<Cameratest>();
        kid= GameObject.Find("Kid").GetComponent<Kid>();
        skillUI = GameObject.Find("System").GetComponent<UIManager>();//���qUI������o�}��
        dialongueSystem = GameObject.Find("System").GetComponent<DialongueSystem>();
        #endregion
    }
    void FixedUpdate()
    {
        if(kid.dalogues2Fin&& !dialongueSystem.display&&speed != objectiveSpeed) TouchTree();
        if (kid.childGrowth&&!task1) SkillTree();//�p�Ī��j��@�P���j

        if (speed == objectiveSpeed&&!taskFin&&!dalogues1Fin) Wilting();
            
        TaskFin();
        //print(Input.touchCount);
        //print(Camera.main);
    }
    #region ��k
    private void TouchTree()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.touches[0];
            Vector3 pos = touch.position;
            //�Y�OĲ�I�}�l
            if (touch.phase == TouchPhase.Began)
            {
                if (ch)
                {
                    RaycastHit chHit;
                    Ray chRay = setCamera.ScreenPointToRay(pos);
                    Physics.Raycast(chRay, out chHit);
                    //print(chHit.transform.parent.gameObject.name);
                    // if (Physics.Raycast(ray, out hit) && hit.transform.parent.gameObject.name == target)
                    startPos = touch.position;
                    begainTime = Time.realtimeSinceStartup;
                    
                    if(chHit.collider.name == "�ޯ�ξ�" && !skillUI.skillOpen)
                    {
                        skillUI.SkillOn(transform);//�}��SKILLUI
                    }
                    if (Time.realtimeSinceStartup - lastTouchTime < quickDoubleTabInterval)
                    {
                        //print("if��");
                        //debugInfo = "touchCount";
                        setCamera.transform.position = new Vector3(27, 8, 49);
                        ch = !ch;
                        setCamera.enabled = ch;
                        oriCamera.enabled = !ch;
                        cameratest.caTask = true;
                    }
                }
                else
                {
                    RaycastHit hit;
                    Ray ray = oriCamera.ScreenPointToRay(pos);
                    //print(hit.transform.parent.gameObject.name);
                    // if (Physics.Raycast(ray, out hit) && hit.transform.parent.gameObject.name == target)
                    startPos = touch.position;
                    begainTime = Time.realtimeSinceStartup;

                    Physics.Raycast(ray, out hit);
                    //print(hit.collider.name);

                    if (Physics.Raycast(ray, out hit) && /*hit.transform.parent.gameObject.name == target &&*/ Time.realtimeSinceStartup - lastTouchTime < quickDoubleTabInterval)
                    {
                        ch = !ch;
                        setCamera.enabled = ch;
                        oriCamera.enabled = !ch;
                        cameratest.caTask = false;
                    }
                }

            }
            if (touch.phase == TouchPhase.Ended)
            {
                intervals = Time.realtimeSinceStartup - begainTime;
                lastTouchTime = Time.realtimeSinceStartup;
                lastTouch = touch;
            }
        }
    }
    private void SkillTree()
    {
        task1 = true;
        StartCoroutine(ChangePtion());
    }
    private IEnumerator ChangePtion()//��{��ܼҫ���1��
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.localScale = new Vector3(1, 1, 1);//��j�ҫ�
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.localScale = new Vector3(3, 3, 3);//��j�ҫ�
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.localScale = new Vector3(5, 5, 5);//��j�ҫ�

    }
    private void TaskFin()
    {
        if (taskFin)
        {
            setCamera.enabled = false;
            oriCamera.enabled = true;
            kid.daloguesTaskFin = true;
            ch = false;
            cameratest.caTask = true;
        }
    }
    public void SkillUse(float get)//��o�ޯ���s���ƭ�
    {
        speed += get;
    }
    private void Wilting()
    {
        dalogues1Fin = true;
        dialongueSystem.StopAllCoroutines();
        dialongueSystem.StartDialogue(dataDalogues[0].conversationContent);//��ܸ��Ū��
        dialongueSystem.NameEnter(dataDalogues[0].talkName);
        if (!dialongueSystem.display) taskFin = true;
    }
    #endregion
}