using UnityEngine;
using System.Collections;
/// <summary>
/// 關卡完成 場景轉換
/// </summary>
public class S1_Completed : MonoBehaviour
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
    [Header("角色")]
    private PlayerCharacter player;
    [Header("開關")]
    public bool playdone0;
    public bool playdone1;
    [Header("位置")]
    public GameObject post;
    private float speed = 50;
    public Transform target;
    #endregion
    private void Start()
    {
        post = this.gameObject;
        task = GameObject.Find("System").GetComponent<CityTask>();
        dialongueSystem = GameObject.Find("System").GetComponent<DialongueSystem>();
        t = GameObject.Find("System").GetComponent<TouchS>();
        player = GameObject.Find("主角").GetComponent<PlayerCharacter>();

    }
    private void Update()
    {
        if (task.d_cleaning && (!playdone0 || post.transform.position != target.transform.position) && area.chIn && !dialongueSystem.display)
        {
            TrinGo();
        }
        if (!playdone1 && playdone0 && !dialongueSystem.display&& post.transform.position == target.transform.position)
        {
            playdone1 = true;
            Confirm();
        }
    }
    #region 方法
    private void Confirm()
    {
        playdone0 = true;
        t.switches = true;//關觸控
        player.transform.LookAt(post.transform);
        dialongueSystem.StopAllCoroutines();
        dialongueSystem.StartDialogue(dataDalogues[0].conversationContent);//對話資料讀取
        dialongueSystem.NameEnter(dataDalogues[0].talkName);

    }
    private void TrinGo()
    {
        //print("移動");
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        playdone0 = true;
    }
    #endregion
}
