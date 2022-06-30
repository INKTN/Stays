using UnityEngine;

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
    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
       if (other.name == target) dialongueSystem.StartDialogue(dataDalogues.conversationContent);//對話資料讀取
    }
    
}
