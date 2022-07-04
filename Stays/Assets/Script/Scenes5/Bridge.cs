using UnityEngine;
/// <summary>
/// 20220606 橋任務
/// </summary>
public class Bridge : MonoBehaviour
{
    #region 欄位
    [Header("速度")]
    public float speed = 1;
    private float objectiveSpeed = 2;
    [Header("橋 搭建")]
    public bool skillUse = false;
    [Header("偵測範圍")]
    public Vector3 detectionRange = Vector3.one;
    public Vector3 detectionHight;
    private string target = "主角";
    [Header("觸碰範圍顯示")]
    public bool gizmosOn;
    [Header("技能系統")]
    private UIManager skillUI;
    [Header("是否完成")]
    public bool fin;
    #endregion
    private void Start()
    {
        //print(gameObject.transform.GetChild(2).gameObject.name);//確認物件名稱
        skillUI = GameObject.Find("System").GetComponent<UIManager>();//先從UI控制中取得腳本
        fin = false;
    }
    private void Update()
    {
        if (speed == objectiveSpeed) BuildBrodge();
    }
    private void OnDrawGizmos()
    {
        if (gizmosOn)
        {
            Gizmos.color = new Color(0, 0, 1, .3f);//判斷區設置為藍色
            Gizmos.DrawCube(transform.position + detectionHight, detectionRange);//偵測區位置
        }
    }//位置偵測顯示
    #region 方法
    public void SkillUse(float get)//獲得技能按鈕的數值
    {
        speed += get;
    }
    private void BuildBrodge()//update若速度與目標速度相同則隱藏看板，顯示橋梁
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
        fin = true;

    }
    public void Skill()
    {
        Collider[] hit = Physics.OverlapBox(transform.position + detectionHight, detectionRange / 2, Quaternion.identity);//(中心點，大小，旋轉，圖層碼)
        int i = 0;
        print(hit[i].name);
        skillUI.SkillOn(transform);
    }
        #endregion
}
