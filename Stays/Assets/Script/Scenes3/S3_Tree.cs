using UnityEngine;
using System.Collections;
public class S3_Tree : MonoBehaviour
{
    #region 欄位
    [Header("攝影機")]
    public Camera setCamera;
    public Camera oriCamera;
    [Header("鏡頭是否為聚焦")]
    public bool ch;
    [Header("其他腳本")]
    private Cameratest cameratest;
    private Kid kid;
    [Header("觸控")]
    private float begainTime = 0f;//最初點擊時間
    private Vector2 startPos = Vector2.zero;//觸碰起始點
    public float quickDoubleTabInterval = 0.15f;
    public float lastTouchTime;//上一次點擊放開的時間
                               //public string debugInfo = "Nothing";
    public string target = "主角";
    private static float intervals;//間隔時間
    private static Touch lastTouch;//目前沒用到，不果主要是記錄上一次的觸碰
    [Header("技能系統")]
    private UIManager skillUI;
    [Header("可否使用技能")]
    public bool canSkill;
    [Header("技能速度")]
    public float speed = 1;
    private float objectiveSpeed = 0;
    [Header("任務完成")]
    public bool task1;
    public bool taskFin = false;
    [Header("對話系統")]
    private DialongueSystem dialongueSystem;
    [Header("對話資料")]
    public DataDalogue[] dataDalogues;//對話系統
    public bool dalogues1Fin;
    [Header("偵測範圍")]
    public Vector3 detectionRange = Vector3.one;
    public Vector3 detectionHight;
    [Header("觸碰範圍顯示")]
    public bool gizmosOn;
    #endregion

    private void Start()
    {
        #region 攝影機
        oriCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
        setCamera = GameObject.Find("TreeCa").GetComponent<Camera>();
        #endregion
        #region 腳本
        cameratest = GameObject.Find("MainCamera").GetComponent<Cameratest>();
        kid= GameObject.Find("Kid").GetComponent<Kid>();
        skillUI = GameObject.Find("System").GetComponent<UIManager>();//先從UI控制中取得腳本
        dialongueSystem = GameObject.Find("System").GetComponent<DialongueSystem>();
        #endregion
    }
    void Update()
    {
        
        //if(kid.dalogues2Fin&& !dialongueSystem.display&&speed != objectiveSpeed) TouchTree();
        if (kid.childGrowth&&!task1) SkillTree();//小孩長大樹一同長大
        if (speed == objectiveSpeed && !taskFin && !dalogues1Fin)
        {
            print("對ㄌ");
            Wilting();
        }
        if (speed >= 2 && !taskFin && !dalogues1Fin)
        {
            //print("減速拉笨蛋");
            Accelerate();
        }
        //if (speed == objectiveSpeed&&!taskFin&&!dalogues1Fin) Wilting();

        TaskFin();
        //print(Input.touchCount);
        //print(Camera.main);
    }
    private void OnDrawGizmos()
    {
        if (gizmosOn)
        {
            Gizmos.color = new Color(1, 0, 0, .5f);//判斷區設置為紅色
            Gizmos.DrawCube(transform.position + detectionHight, detectionRange);//偵測區位置
        }
    }//位置偵測顯示
    #region 方法
    private void TouchTree()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.touches[0];
            Vector3 pos = touch.position;
            //若是觸碰開始
            if (touch.phase == TouchPhase.Began)
            {
                setCamera.transform.position = new Vector3(27, 8, 49);
                if (ch)
                {
                    RaycastHit chHit;
                    Ray chRay = setCamera.ScreenPointToRay(pos);
                    Physics.Raycast(chRay, out chHit);
                    //print(chHit.transform.parent.gameObject.name);
                    // if (Physics.Raycast(ray, out hit) && hit.transform.parent.gameObject.name == target)
                    startPos = touch.position;
                    begainTime = Time.realtimeSinceStartup;
                    
                    if(chHit.collider.name == "技能用樹" && !skillUI.skillOpen)
                    {
                        skillUI.SkillOn(transform);//開啟SKILLUI
                    }
                    if (Time.realtimeSinceStartup - lastTouchTime < quickDoubleTabInterval)
                    {
                        //print("if測");
                        //debugInfo = "touchCount";
                        //setCamera.transform.position = new Vector3(27, 8, 49);
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
                    if(speed == objectiveSpeed && !taskFin && !dalogues1Fin) Wilting();
                    if (speed <= objectiveSpeed && !taskFin && !dalogues1Fin) Wilting();
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
    private IEnumerator ChangePtion()//協程顯示模型晚1秒
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.localScale = new Vector3(1, 1, 1);//放大模型
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.localScale = new Vector3(3, 3, 3);//放大模型
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.localScale = new Vector3(5, 5, 5);//放大模型

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
    public void SkillUse(float get)//獲得技能按鈕的數值
    {
        speed += get;
    }
    private void Wilting()
    {
        dalogues1Fin = true;
        dialongueSystem.StopAllCoroutines();
        dialongueSystem.StartDialogue(dataDalogues[0].conversationContent);//對話資料讀取
        dialongueSystem.NameEnter(dataDalogues[0].talkName);
        taskFin = true;
    }
    public void Check()//檢測內部是否有東西並呼叫對話
    {
        //print("接收回傳");
        Collider[] hit = Physics.OverlapBox(transform.position + detectionHight, detectionRange / 2, Quaternion.identity);//(中心點，大小，旋轉，圖層碼)
        int i = 0;

        while (i < hit.Length)//若i小於hit最大值
        {
            //print(hit[i].name);
            //Contains:在字串中尋找，若有回傳True
            #region 對話
            if (hit[i].name.Contains(target))
            {
                if (kid.dalogues2Fin && !dialongueSystem.display && speed != objectiveSpeed && cameratest.caTask)
                {
                   // hit[i]= null;
                   // print("樹接收回傳"+i);
                    Skill();
                }
                 if(kid.dalogues2Fin && !dialongueSystem.display && speed != objectiveSpeed)
                 {
                    // print("開技能"+i);
                     skillUI.SkillOn(transform);//開啟SKILLUI
                 }
                
            }
             /*else
             {
                 ch = !ch;
                 setCamera.enabled = ch;
                 oriCamera.enabled = !ch;
                 cameratest.caTask = false;
             }*/
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
        skillUI.SkillOn(transform);//開啟SKILLUI

    }
    private void Accelerate()
    {
        dialongueSystem.StopAllCoroutines();
        dialongueSystem.StartDialogue(dataDalogues[1].conversationContent);//對話資料讀取
        dialongueSystem.NameEnter(dataDalogues[1].talkName);
        speed = 1;
        setCamera.enabled = false;
        oriCamera.enabled = true;
        kid.daloguesTaskFin = true;
        ch = false;
        cameratest.caTask = true;
    }
    #endregion
}