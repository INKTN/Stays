using UnityEngine;
/// <summary>
/// 售票員 20230304
/// </summary>
public class S1_Ticket : MonoBehaviour
{
    #region 欄位
    [Header("對話資料")]
    public DataDalogue[] dataDalogues;
    [Header("對話系統")]
    public DialongueSystem dialongueSystem;
    [Header("觸發區域")]
    public area area;
    [Header("任務偵測")]
    private CityTask task;
    [Header("觸控開關")]
    private TouchS t;
    [Header("攝影機")]
    public Camera cameraControl;
    [Header("角色")]
    private PlayerCharacter player;
    [Header("開關")]
    public bool playdone0;
    [Header("位置")]
    public GameObject post;
    #endregion
    private void Start()
    {
        post = this.gameObject;
        task = GameObject.Find("System").GetComponent<CityTask>();
        dialongueSystem = GameObject.Find("System").GetComponent<DialongueSystem>();
        t = GameObject.Find("System").GetComponent<TouchS>();
        player = GameObject.Find("主角").GetComponent<PlayerCharacter>();
    }

    private void FixedUpdate()
    {
        if (task.b_towerDialogue && !playdone0 && area.chIn && !dialongueSystem.display)
        {
            Buy();
        }
        if ( playdone0 && !dialongueSystem.display)
            t.switches = false;//開觸控
    }
    #region 方法
    private void Buy()
    {
        t.switches = true;//關觸控
        player.transform.LookAt(post.transform);
        dialongueSystem.StopAllCoroutines();
        dialongueSystem.StartDialogue(dataDalogues[0].conversationContent);//對話資料讀取
        dialongueSystem.NameEnter(dataDalogues[0].talkName);
        playdone0 = true;

    }

    #endregion
}
