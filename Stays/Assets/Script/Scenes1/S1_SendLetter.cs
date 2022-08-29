using UnityEngine;
/// <summary>
/// 送信任務 20220807
/// </summary>
public class S1_SendLetter : MonoBehaviour
{
    #region 欄位
    [Header("任務判定")]
    private CityTask task;
    [Header("對話資料")]
    public DataDalogue[] dataDalogues;

    [Header("對話系統")]
    public DialongueSystem dialongueSystem;
    [Header("區域")]
    public area area;
    public bool finRead;
    [Header("主角")]
    private PlayerCharacter player;
    #endregion
    private void Start()
    {
        task = GameObject.Find("System").GetComponent<CityTask>();
        dialongueSystem= GameObject.Find("System").GetComponent<DialongueSystem>();
        area = gameObject.transform.GetChild(0).GetComponent<area>();
        player = GameObject.Find("主角").GetComponent<PlayerCharacter>();
    }
    private void FixedUpdate()
    {
        Detection();
        
    }
    #region 方法
    private void Detection()
    {
        if (area.chIn && !finRead &&!player.walking)
        {
            dialongueSystem.StartDialogue(dataDalogues[0].conversationContent);//對話資料讀取
            dialongueSystem.NameEnter(dataDalogues[0].talkName);
            finRead = true;
            task.a_done++;
        }

    }
    #endregion
}
