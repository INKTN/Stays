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
    public string debugInfo = "Nothing";
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
    public bool skillUse = false;

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
        #endregion
    }
    void FixedUpdate()
    {
        if(kid.dalogues1Fin)TouchTree();
        if (speed == objectiveSpeed && !skillUse) SkillTree();
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
                    print(chHit.transform.parent.gameObject.name);
                    // if (Physics.Raycast(ray, out hit) && hit.transform.parent.gameObject.name == target)
                    startPos = touch.position;
                    begainTime = Time.realtimeSinceStartup;

                    if(chHit.collider.name == "�ޯ�ξ�" && !skillUI.skillOpen)
                    {
                        skillUI.SkillOn(transform);//�}��SKILLUI
                    }
                    if (Time.realtimeSinceStartup - lastTouchTime < quickDoubleTabInterval)
                    {
                        print("if��");
                        debugInfo = "touchCount";
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
                    Physics.Raycast(ray, out hit);
                    print(hit.transform.parent.gameObject.name);
                    // if (Physics.Raycast(ray, out hit) && hit.transform.parent.gameObject.name == target)
                    startPos = touch.position;
                    begainTime = Time.realtimeSinceStartup;
                    if (Physics.Raycast(ray, out hit) && hit.transform.parent.gameObject.name == target && Time.realtimeSinceStartup - lastTouchTime < quickDoubleTabInterval)
                    {
                        //print("if��");
                        debugInfo = "touchCount";
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
        StartCoroutine(ChangePtion());
    }
    private IEnumerator ChangePtion()//��{��ܼҫ���1��
    {
        yield return new WaitForSeconds(0.5f);
       // gameObject.transform.localScale = speed;
        skillUse = true;

    }
    #endregion
}