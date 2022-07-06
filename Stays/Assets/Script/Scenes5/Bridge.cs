using System.Collections;
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
    private string target = "主角";
    private PlayerCharacter player;
    [Header("技能系統")]
    private UIManager skillUI;
    [Header("可否使用技能")]
    public bool canSkill;
    [Header("完成傳送")]
    public Vector3 finPin;

    #endregion
    private void Start()
    {
        //print(gameObject.transform.GetChild(2).gameObject.name);//確認物件名稱
        skillUI = GameObject.Find("System").GetComponent<UIManager>();//先從UI控制中取得腳本
        player = GameObject.Find(target).GetComponent<PlayerCharacter>();
    }

    private void Update()
    {
        if (speed == objectiveSpeed&&!skillUse) BuildBrodge();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == target)
        {
            canSkill = true;
        }
    }

    #region 方法
    public void SkillUse(float get)//獲得技能按鈕的數值
    {
        speed += get;
    }
    private void BuildBrodge()//update若速度與目標速度相同則隱藏看板，顯示橋梁
    {

        StartCoroutine(ChangePtion());
    }
    public void Skill()
    {
        if (canSkill&&!skillUse)
        {

        skillUI.SkillOn(transform);

        }
    }
    private IEnumerator ChangePtion()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
        skillUse = true;
        yield return new WaitForSeconds(0.5f);
        player.Location(finPin);
        
    }
        #endregion
}
