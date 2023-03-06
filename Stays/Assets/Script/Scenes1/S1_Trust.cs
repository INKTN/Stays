using System.Collections;
using UnityEngine;
/// <summary>
/// 接信件任務
/// </summary>

public class S1_Trust : MonoBehaviour
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
    #endregion
    private void Start()
    {
        post = this.gameObject;
        task = GameObject.Find("System").GetComponent<CityTask>();
        dialongueSystem = GameObject.Find("System").GetComponent<DialongueSystem>();
        t = GameObject.Find("System").GetComponent<TouchS>();
        player = GameObject.Find("主角").GetComponent<PlayerCharacter>();
    }
    #region 方法
    private void FixedUpdate()
    {
        if (task.b_towerDialogue && !playdone0 && area.chIn && !dialongueSystem.display)
        {
            StartCoroutine(Meet());
        }
        if(!playdone1 && playdone0 && !dialongueSystem.display)
        {
            StartCoroutine(Confirm());
        }
        if (playdone1 && playdone0 && !dialongueSystem.display)
            t.switches = false;//開觸控
    }
    private IEnumerator Meet()
    {
        t.switches = true;//關觸控
        yield return new WaitForSeconds(2);
        player.transform.LookAt(post.transform);
        dialongueSystem.StopAllCoroutines();
        dialongueSystem.StartDialogue(dataDalogues[0].conversationContent);//對話資料讀取
        dialongueSystem.NameEnter(dataDalogues[0].talkName);
        playdone0 = true;
        
    }
    private IEnumerator Confirm()
    {
        t.switches = true;//關觸控
        yield return new WaitForSeconds(2);
        player.transform.LookAt(post.transform);
        dialongueSystem.StopAllCoroutines();
        dialongueSystem.StartDialogue(dataDalogues[1].conversationContent);//對話資料讀取
        dialongueSystem.NameEnter(dataDalogues[1].talkName);
        playdone1 = true;

    }
    #endregion
}
