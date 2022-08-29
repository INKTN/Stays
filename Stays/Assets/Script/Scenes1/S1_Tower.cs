using UnityEngine;
using System.Collections;
/// <summary>
/// 鐘塔劇情20220810
/// </summary>
public class S1_Tower : MonoBehaviour
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
    private Cameratest cameratest;
    public Camera camera_Tower;
    public Camera camera_NPC;
    //public Vector3[] pot;
    [Header("NPC")]
    public GameObject npc;
    public float speed = 1;
    private S1_ManipulationNPC s1_ManipulationNPC;
    [Header("開關")]
    public bool playdone0;
    public bool playdone1;
    public bool playdone2;
    public bool playdone3;
    public bool playdone4;
    [Header("完成傳送")]
    public Vector3 finPin;
    private PlayerCharacter player;
    private GameObject target;

    #endregion
    private void Start()
    {
        task = GameObject.Find("System").GetComponent<CityTask>();
        dialongueSystem = GameObject.Find("System").GetComponent<DialongueSystem>();
        t= GameObject.Find("System").GetComponent<TouchS>();
        cameratest = cameraControl.GetComponent<Cameratest>();
        s1_ManipulationNPC = npc.GetComponent<S1_ManipulationNPC>();
        player = GameObject.Find("主角").GetComponent<PlayerCharacter>();
    }
    private void FixedUpdate()
    {
        Plot();
        StartDialogue();
    }
    #region 方法
    private void Plot()
    {
        if (task.a_finish && !playdone0 && area.chIn)
        {
            dialongueSystem.StartDialogue(dataDalogues[0].conversationContent);//對話資料讀取
            dialongueSystem.NameEnter(dataDalogues[0].talkName);
            playdone0 = true;
        }
    }
    public void StartDialogue()
    {
        if (task.a_finish && !playdone0 && area.chIn)
        {
            StartCoroutine(Performance());
        }
        if (playdone0 && !dialongueSystem.display && !playdone1)
        { FocusTower(); }
        if (!playdone2 && !dialongueSystem.display && playdone1)
        { StartCoroutine(FocusNPC()); }
        if (playdone2 && !dialongueSystem.display && !playdone3) StartCoroutine(TalkTower());
        if (playdone3 && !dialongueSystem.display && !playdone4) StartCoroutine(TowerEnd());
        if (playdone0 && playdone2 && playdone1 && playdone3 && playdone4 && !dialongueSystem.display) StartCoroutine(GoStation());
    }
    private IEnumerator Performance()
    {
        cameratest.switches = true;//關鏡頭移動
        t.switches = true;//關觸控
        print("輸出:"+0);
        //角色動畫
        yield return new WaitForSeconds(5);
        dialongueSystem.StartDialogue(dataDalogues[0].conversationContent);//對話資料讀取
        dialongueSystem.NameEnter(dataDalogues[0].talkName);
        
        playdone0 = true;   

    }
    private void FocusTower()
    {
        camera_Tower.enabled = true;
        cameraControl.enabled=false;//鏡頭切換
        cameratest.switches = true; cameratest.caTask = false;//關鏡頭移動
                                                             //yield return new WaitForSeconds(1);
        print("輸出:" + 1);
        dialongueSystem.StartDialogue(dataDalogues[1].conversationContent);//對話資料讀取
        dialongueSystem.NameEnter(dataDalogues[1].talkName);
        playdone1 = true;
    }
    private IEnumerator FocusNPC()
    {
        playdone2 = true;
        cameratest.switches = true;cameratest.caTask = false;//關鏡頭移動
        t.switches = true;//關觸控
        camera_NPC.enabled = true;
        camera_Tower.enabled = false;//鏡頭切換
        s1_ManipulationNPC.Normal();//NPC移動
        print("輸出:" + 2);
        yield return new WaitForSeconds(2);
        s1_ManipulationNPC.speed = 0.8f;
        dialongueSystem.StartDialogue(dataDalogues[2].conversationContent);//對話資料讀取
        dialongueSystem.NameEnter(dataDalogues[2].talkName);
    }
    private IEnumerator TalkTower()
    {
        playdone3 = true;
        cameratest.switches = true; cameratest.caTask = false;//關鏡頭移動
        t.switches = true;//關觸控
        camera_NPC.enabled = true;//鏡頭切換
        camera_Tower.enabled = false;
        yield return new WaitForSeconds(2);
        print("輸出:" + 3);
        dialongueSystem.StartDialogue(dataDalogues[3].conversationContent);//對話資料讀取
        dialongueSystem.NameEnter(dataDalogues[3].talkName);
    }
    private IEnumerator TowerEnd()
    {
        playdone4 = true;
        cameratest.switches = false; cameratest.caTask = true;//關鏡頭移動
        t.switches = false;//關觸控
        camera_Tower.enabled = true;//鏡頭切換
        camera_NPC.enabled = false;
        print("輸出:" + 4);
        yield return new WaitForSeconds(0.5F);
        dialongueSystem.StartDialogue(dataDalogues[4].conversationContent);//對話資料讀取
        dialongueSystem.NameEnter(dataDalogues[4].talkName);

    }
    private IEnumerator GoStation()
    {
        cameratest.switches = false; cameratest.caTask = true;//關鏡頭移動
        t.switches = false;//關觸控
        cameraControl.enabled = true;//鏡頭切換
        camera_Tower.enabled = false;
        yield return new WaitForSeconds(2F);
        player.Location(finPin);
        player.Move(target.transform);

    }
        #endregion
}
