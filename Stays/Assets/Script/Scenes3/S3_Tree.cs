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
    public string debugInfo = "Nothing";
    public string target;
    private static float intervals;//間隔時間
    private static Touch lastTouch;//目前沒用到，不果主要是記錄上一次的觸碰
    [Header("技能系統")]
    private UIManager skillUI;
    [Header("可否使用技能")]
    public bool canSkill;
    [Header("技能速度")]
    public float speed = 1;
    private float objectiveSpeed = 2;
    [Header("任務完成")]
    public bool skillUse = false;

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
        #endregion
    }
    void FixedUpdate()
    {
        if(kid.dalogues1Fin)TouchTree();
        if (speed == objectiveSpeed && !skillUse) SkillTree();
        //print(Input.touchCount);
        //print(Camera.main);
    }
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
                if (ch)
                {
                    RaycastHit chHit;
                    Ray chRay = setCamera.ScreenPointToRay(pos);
                    Physics.Raycast(chRay, out chHit);
                    print(chHit.transform.parent.gameObject.name);
                    // if (Physics.Raycast(ray, out hit) && hit.transform.parent.gameObject.name == target)
                    startPos = touch.position;
                    begainTime = Time.realtimeSinceStartup;

                    if(chHit.collider.name == "技能用樹" && !skillUI.skillOpen)
                    {
                        skillUI.SkillOn(transform);//開啟SKILLUI
                    }
                    if (Time.realtimeSinceStartup - lastTouchTime < quickDoubleTabInterval)
                    {
                        print("if測");
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
                        //print("if測");
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
    private IEnumerator ChangePtion()//協程顯示模型晚1秒
    {
        yield return new WaitForSeconds(0.5f);
       // gameObject.transform.localScale = speed;
        skillUse = true;

    }
    #endregion
}