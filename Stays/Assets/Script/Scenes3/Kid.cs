using UnityEngine;
using System.Collections;
/// <summary>
/// 小孩NPC腳本20220701
/// </summary>

public class Kid : MonoBehaviour
{
    #region 欄位
    [Header("動畫欄位")]
    private Animator an;
    [Header("對話資料")]
    public DataDalogue[] dataDalogues;//對話系統
    [Header("各式判定")]
    public bool dalogues1Fin;//接第一次任務
    public bool childGrowth;//使用技能
    public bool dalogues2Fin;
    public bool daloguesTaskFin;//任務完成對話

    [Header("對話系統")]
    private DialongueSystem dialongueSystem;
    [Header("觸發對象")]
    public string target = "主角";
    [Header("鏡頭是否為聚焦")]
    public bool ch;
    [Header("其他腳本")]
    private Cameratest cameratest;
    [Header("對應物件")]
    public GameObject taskTa;//樹
    private S3_Tree tree;
    public Camera setCamera;
    public Camera oriCamera;
    public GameObject initial;//小孩模型
    public GameObject adultModels;//成年人模型
    public bool tastBool;
    [Header("偵測範圍")]
    public Vector3 detectionRange = Vector3.one;
    public Vector3 detectionHight;
    [Header("觸碰範圍顯示")]
    public bool gizmosOn;
    private UIManager skillUI;
    //private Cameratest cameratest;
    [Header("技能使用")]
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
        if (!childGrowth && speed == 2)//使用技能後
        {
            childGrowth = true;
            StartCoroutine(ChangePtion());
        }
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
    public void Check()//檢測內部是否有東西並呼叫對話
    {
        ///print("接收回傳");
        Collider[] hit = Physics.OverlapBox(transform.position + detectionHight, detectionRange / 2, Quaternion.identity);//(中心點，大小，旋轉，圖層碼)
        int i = 0;
        transform.LookAt(GameObject.Find("主角").transform);
        while (i < hit.Length)//若i小於hit最大值
        {
            //print(hit[i].name);
            //Contains:在字串中尋找，若有回傳True
            #region 對話
            if (hit[i].name.Contains(target)) 
            {
                if (!dalogues1Fin)
                {
                    dialongueSystem.StopAllCoroutines();
                    dialongueSystem.StartDialogue(dataDalogues[0].conversationContent);//對話資料讀取
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
                    dialongueSystem.StartDialogue(dataDalogues[1].conversationContent);//對話資料讀取
                    dialongueSystem.NameEnter(dataDalogues[1].talkName);
                    dalogues2Fin = true;
                }
                else if (!dialongueSystem.display &&tree.taskFin)
                {
                    dialongueSystem.StopAllCoroutines();
                    dialongueSystem.StartDialogue(dataDalogues[2].conversationContent);//對話資料讀取
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
    private IEnumerator ChangePtion()//協程顯示模型晚1秒
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.transform.localScale = new Vector3(1, 1, 1);//放大模型
        yield return new WaitForSeconds(0.2f);
        adultModels.SetActive(true);//開啟成年人模型顯示
        initial.SetActive (false);//關閉小孩模型顯示

    }
    #endregion
}
