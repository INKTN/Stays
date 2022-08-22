using UnityEngine;

public class S1_Start : MonoBehaviour
{
    #region 欄位
    [Header("對話資料")]
    public DataDalogue[] dataDalogues;

    [Header("對話系統")]
    public DialongueSystem dialongueSystem;
    [Header("區域")]
    public area area;
    public bool finRead;
    #endregion
    private void Start()
    {
        area = gameObject.transform.GetChild(0).GetComponent<area>();
    }
    private void FixedUpdate()
    {
        Detection();

    }
    #region 方法
    private void Detection()
    {
        if (area.chIn && !finRead)
        {
            dialongueSystem.StartDialogue(dataDalogues[0].conversationContent);//對話資料讀取
            dialongueSystem.NameEnter(dataDalogues[0].talkName);
            finRead = true;
        }

    }
    #endregion
}
