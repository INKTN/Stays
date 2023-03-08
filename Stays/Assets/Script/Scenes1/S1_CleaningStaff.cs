using UnityEngine;
/// <summary>
/// 清潔員任務 20230306
/// </summary>
public class S1_CleaningStaff : MonoBehaviour
{
    #region 欄位
    [Header("對話資料")]
    public DataDalogue[] dataDalogues;
    [Header("對話系統")]
    private DialongueSystem dialongueSystem;

    [Header("觸發區域")]
    public area area;
    [Header("任務偵測")]
    private CityTask task;
    [Header("觸控開關")]
    private TouchS t;
    [Header("攝影機")]
    public Camera oriCamera;
    public Camera setCamera;
    [Header("角色")]
    private PlayerCharacter player;
    #region 開關
    [Header("開關")]
    public bool playdone0;
    public bool playdone1;
    public bool cleanerAway;//使用技能
    #endregion
    [Header("位置")]
    private GameObject post;

    [Header("觸發對象")]
    public string target = "主角";
    [Header("鏡頭是否為聚焦")]
    public bool ch;
    [Header("其他腳本")]
    private Cameratest cameratest;
    [Header("偵測範圍")]
    public Vector3 detectionRange = Vector3.one;
    public Vector3 detectionHight;
    [Header("觸碰範圍顯示")]
    public bool gizmosOn;
    private UIManager skillUI;
    [Header("技能使用")]
    public float speed = 1;
    //public bool man;
    #endregion
    private void Start()
    {
        post = this.gameObject;
        task = GameObject.Find("System").GetComponent<CityTask>();
        dialongueSystem = GameObject.Find("System").GetComponent<DialongueSystem>();
        t = GameObject.Find("System").GetComponent<TouchS>();
        player = GameObject.Find("主角").GetComponent<PlayerCharacter>();
        oriCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
        skillUI = GameObject.Find("System").GetComponent<UIManager>();
        cameratest = GameObject.Find("MainCamera").GetComponent<Cameratest>();
    }
    private void OnDrawGizmos()
    {
        if (gizmosOn)
        {
            Gizmos.color = new Color(1, 0, 0, .5f);//判斷區設置為紅色
            Gizmos.DrawCube(transform.position + detectionHight, detectionRange);//偵測區位置
        }
    }//位置偵測顯示
    private void FixedUpdate()
    {
        if (task.b_towerDialogue && !playdone0 && area.chIn && !dialongueSystem.display)
        {
            Meet();
        }
        if (playdone0 && !dialongueSystem.display)
            t.switches = false;//開觸控
        if (!cleanerAway && speed == 2)//使用技能後
        {
            cleanerAway = true;
           
        }
    }
    #region 方法
    private void Meet()
    {
        t.switches = true;//關觸控
        player.transform.LookAt(post.transform);
        dialongueSystem.StopAllCoroutines();
        dialongueSystem.StartDialogue(dataDalogues[0].conversationContent);//對話資料讀取
        dialongueSystem.NameEnter(dataDalogues[0].talkName);
        playdone0 = true;

    }
    public void Skill()
    {
        ch = !ch;
        setCamera.enabled = ch;
        oriCamera.enabled = !ch;
        cameratest.caTask = false;
        skillUI.SkillOn(transform);//開啟SKILLUI

    }
    public void SkillUse(float get)//獲得技能按鈕的數值
    {
        ch = !ch;
        setCamera.enabled = false;
        oriCamera.enabled = true;
        cameratest.caTask = true;
        speed += get;
        //print("小孩加速");

    }
    public void Check()//檢測內部是否有東西並呼叫對話
    {
        print("接收回傳");
        Collider[] hit = Physics.OverlapBox(transform.position + detectionHight, detectionRange / 2, Quaternion.identity);//(中心點，大小，旋轉，圖層碼)
        int i = 0;
        
       /* while (i < hit.Length)//若i小於hit最大值
        {
            //print(hit[i].name);
            //Contains:在字串中尋找，若有回傳True
            #region 對話
            if (hit[i].name.Contains(target))
            {
                if (!playdone1&&playdone0&& !dialongueSystem.display&&speed != 2)
                {
                    transform.LookAt(setCamera.transform);
                    Skill();
                }
            }
            #endregion
        }*/
    }
                   
    #endregion
  }
