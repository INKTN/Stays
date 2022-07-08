using UnityEngine;
/// <summary>
/// 小孩NPC腳本20220701
/// </summary>

public class Kid : MonoBehaviour
{
    #region 欄位
    [Header("動畫欄位")]
    private Animator an;
    [Header("對話資料")]
    public DataDalogue[] dataDalogues;
    public bool dalogues1Fin;
    [Header("對話系統")]
    public DialongueSystem dialongueSystem;
    [Header("觸發對象")]
    public string target = "主角";
    [Header("對應物件")]
    public GameObject taskTa;
    public Camera setCamera;
    public Camera oriCamera;
    public bool tastBool;
    [Header("偵測範圍")]
    public Vector3 detectionRange = Vector3.one;
    public Vector3 detectionHight;
    [Header("觸碰範圍顯示")]
    public bool gizmosOn;
    //private Cameratest cameratest;

    #endregion
    private void Start()
    {
        an = GetComponent<Animator>();
        oriCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void Update()
    {
       // ControlCa();
    }

    private void OnDrawGizmos()
    {
        if (gizmosOn)
        {
            Gizmos.color = new Color(1, 0, 0, .5f);//判斷區設置為藍色
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
            print(hit[i].name);
            //Contains:在字串中尋找，若有回傳True
            #region 對話
            if (hit[i].name.Contains(target)) 
            {
                if (!dalogues1Fin)
                {
                    dialongueSystem.StartDialogue(dataDalogues[0].conversationContent);//對話資料讀取
                    dialongueSystem.NameEnter(dataDalogues[0].talkName);
                    dalogues1Fin = true;
                    ControlCa();
                }
                else
                {
                    dialongueSystem.StartDialogue(dataDalogues[1].conversationContent);//對話資料讀取
                    dialongueSystem.NameEnter(dataDalogues[1].talkName);
                }
            }
            #endregion
            i++;
        }
    }
    public void ControlCa()
    {
        //oriCamera.enabled = tastBool;
        if (dalogues1Fin) 
        {
            //cameratest.TaskShot(taskTa.transform);
            setCamera.enabled = dalogues1Fin;
            oriCamera.enabled = tastBool;

        }
    }
    #endregion
}
