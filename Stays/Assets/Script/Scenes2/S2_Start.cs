using UnityEngine;
using System.Collections;
/// <summary>
/// 20230506 開始動畫
/// </summary>
public class S2_Start : MonoBehaviour
{
    #region 欄位
    [Header("主角")]
    public Transform player;
    
    [Header("對話資料")]
    public DataDalogue[] dataDalogues;
    [Header("對話系統")]
    private DialongueSystem dialongueSystem;
    [Header("劇情播放")]
    public bool playdone0; 
    public bool playdone1;
    [Header("觸控開關")]
    private TouchS t;
    [Header("位置")]
    //public GameObject post;
    private float speed = 20;
    public Transform target;
    #endregion
    private void Start()
    {
        player.transform.localScale = new Vector3(0, 0,0);
        dialongueSystem = GameObject.Find("System").GetComponent<DialongueSystem>();
        t = GameObject.Find("System").GetComponent<TouchS>();
        StartCoroutine(Storyline());
    }
    private void Update()
    {
        
    }
    #region 方法
    private IEnumerator Storyline()//劇情播放
    {
        playdone0 = true;
        t.switches = true;//關觸控
        while (transform.position != target.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            playdone1 = true;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(1f);
        float i = 0;
        while(i<1.5)
        {
           player.transform.localScale = new Vector3(i, i, i);
            //print(i);
           i= i + 0.1F;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.5f);
        dialongueSystem.StopAllCoroutines();
        dialongueSystem.StartDialogue(dataDalogues[0].conversationContent);//對話資料讀取
        dialongueSystem.NameEnter(dataDalogues[0].talkName);
    }
    private void TrinGo()
    {
        //print("移動");
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        playdone1 = true;
    }
    #endregion
}
