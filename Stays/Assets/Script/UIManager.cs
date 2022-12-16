using UnityEngine.UI;
using UnityEngine;
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

    [Header("左側按鈕列")]
    public GameObject setting;
    private Cameratest cameratest;
    [Header("對話系統")]
    private DialongueSystem dialongueSystem;

    #endregion

    private void Start()
    {
        setting = GameObject.Find("關卡內UI");
        cameratest = GameObject.Find("MainCamera").GetComponent<Cameratest>();
        dialongueSystem = GameObject.Find("System").GetComponent<DialongueSystem>();
    }
    private void FixedUpdate()
    {
        //聚焦、對話框顯示時時設定UI不顯示
        if (cameratest.caTask&& !dialongueSystem.display) setting.SetActive(true);
        else if(!cameratest.caTask || dialongueSystem.display) { setting.SetActive(false); }
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
    
    #endregion
}
