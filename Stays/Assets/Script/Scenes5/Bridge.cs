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
    public bool skillUse=false;
    #endregion
    private void Start()
    {
        //print(gameObject.transform.GetChild(2).gameObject.name);//確認物件名稱
    }
    private void Update()
    {
        if (speed == objectiveSpeed) BuildBrodge();
    }
    #region 方法
    public void SkillUse(float get)//獲得技能按鈕的數值
    {
        speed += get;
    }
    private void BuildBrodge()//update若速度與目標速度相同則隱藏看板，顯示橋梁
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(true);

    }
    #endregion
}
