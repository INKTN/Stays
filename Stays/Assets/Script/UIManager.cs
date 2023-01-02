using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
/// <summary>
/// 20220416 UI顯示 獨立
/// 20221217 設定框顯示
/// </summary>

public class UIManager : MonoBehaviour
{
    #region 欄位
    [Header("技能氣泡框")]
    public Image skill;
    //實例化欄位
    private Image uiUse;
    public Transform touchObject;
    [Header("顯示位置")]
    public Vector3 onObject = new Vector3(0, 2.5f, 0);
    //技能UI是否打開
    public bool skillOpen = false;

    public int coldTime = 100;//設定冷卻時間
    private int cold;//實際冷卻時間
    [Header("對話系統")]
    private DialongueSystem dialongueSystem;
    [Header("左側按鈕列")]
    public GameObject setting;
    public GameObject settingPage;
    public GameObject tipsPage;
    public GameObject resetPage;
    public GameObject back;
    private Cameratest cameratest;
    private Blur blurCam;
    private TouchS touchS;
    [Header("退出鍵")]
    public GameObject exitMessage;
    private GameObject sceneExit;
    

    #endregion

    private void Start()
    {
        
        setting = GameObject.Find("關卡內UI");
        cameratest = GameObject.Find("MainCamera").GetComponent<Cameratest>();
        blurCam= GameObject.Find("MainCamera").GetComponent<Blur>();
        touchS= GameObject.Find("System").GetComponent<TouchS>();
        dialongueSystem = GameObject.Find("System").GetComponent<DialongueSystem>();
    }
    private void Update()
    {
        
        //返回
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //若一秒沒有點兩次，生成提示，如果有則退出遊戲
            if (sceneExit == null)
            {
                sceneExit = Instantiate(exitMessage, FindObjectOfType<Canvas>().transform) as GameObject;
                StartCoroutine("RestQuitMessage");
            }
            else
            {
                
                    //非首頁回首頁
                SceneManager.LoadScene("首頁");

                
            }
        }
        //聚焦、對話框顯示時時設定UI不顯示
        if(!cameratest.caTask || dialongueSystem.display ||tipsPage.active||resetPage.active||settingPage.active) 
        { setting.SetActive(false); }
        else if (cameratest.caTask&& !dialongueSystem.display) setting.SetActive(true);
        if (!cameratest.caTask && !dialongueSystem.display) back.SetActive(true);
        else { back.SetActive(false); }
        //顯示氣泡框
        if (skillOpen)
        {
            if (touchObject == null)
            {
                Destroy(GameObject.Find("skill UI(Clone)"));
                skillOpen = false;
            }
        //顯示位置在點擊物件位置
            //uiUse.transform.position = Camera.main.WorldToScreenPoint(touchObject.position+onObject);
            
            if (cold == coldTime)//當冷卻時間到 刪除不使用的SKILLUI
            {
                Destroy(GameObject.Find("skill UI(Clone)"));
                print("刪除UI");
                skillOpen = false;
                
            }
            else cold++;

        }
       
    }
    #region 方法

    public void SkillOn(Transform selection)
    {
        if (!skillOpen)
        {
            skillOpen = true;//SKILLOPEN為開
            touchObject = selection;//選擇物件
                                    //實例化(技能氣泡框,在Canvas位置下).的Bttion
                                    //BUG 畫面中心會多出現一個
            uiUse = Instantiate(skill, FindObjectOfType<Canvas>().transform);//實例化.GetComponent<Image>();
                                                                             //顯示位置在點擊物件位置
                                                                             //uiUse.transform.position = Camera.main.WorldToScreenPoint(touchObject.position+onObject);
            cold = 0;//計時用來清除
        }
    }
    #region 按鈕使用
    public void Set()//叫出設定頁面
    {
        touchS.switches = true;//關觸控
        blurCam.iterations = 4;//背景模糊
        settingPage.SetActive(true);
    }
    public void Tip()//叫出提示頁面
    {
        touchS.switches = true;//關觸控
        blurCam.iterations = 4;//背景模糊
        tipsPage.SetActive(true);
    }
    public void Re()//叫出重設頁面
    {
        touchS.switches = true;//關觸控
        blurCam.iterations = 4;//背景模糊
        resetPage.SetActive(true);
    }
    public void Back()
    {
        touchS.switches = false;//開觸控
        blurCam.iterations = 0;//關背景模糊
        settingPage.SetActive(false);
        tipsPage.SetActive(false);
        resetPage.SetActive(false);
    }
    public void BackCa()
    {

    }
    #endregion
    #region 返回鍵
    private IEnumerator RestQuitMessage()
    {
        yield return new WaitForSeconds(1f);
        
        if (sceneExit != null)
        {
            Destroy(sceneExit);
            
        }
    }
    #endregion
    #endregion
}
