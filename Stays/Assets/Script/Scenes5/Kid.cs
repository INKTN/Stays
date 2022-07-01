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
    public DataDalogue dataDalogues;
    [Header("對話系統")]
    public DialongueSystem dialongueSystem;
    [Header("觸發對象")]
    public string target = "主角";
    [Header("偵測範圍")]
    public Vector3 detectionRange = Vector3.one;
    public Vector3 detectionHight;
    
    #endregion

    private void Start()
    {
        an = GetComponent<Animator>();
    }
    private void OnDrawGizmos()
    {

        Gizmos.color = new Color(1, 0, 0, .5f);//判斷區設置為藍色
        Gizmos.DrawCube(transform.position + detectionHight, detectionRange);//偵測區位置

    }//位置偵測顯示
  
    #region 方法
    public void Check()//檢測內部是否有東西
    {
        print("接收回傳");
        Collider[] hit = Physics.OverlapBox(transform.position + detectionHight, detectionRange / 2, Quaternion.identity);//(中心點，大小，旋轉，圖層碼)
        int i = 0;
        while (i < hit.Length)//若i小於hit最大值
        {
            print(hit[i].name);
            //Contains:在字串中尋找，若有回傳True
            if (hit[i].name.Contains(target)) 
            {
                dialongueSystem.StartDialogue(dataDalogues.conversationContent);//對話資料讀取
                dialongueSystem.NameEnter(dataDalogues.talkName);
            }
            
            i++;
        }
    }
    #endregion
}
