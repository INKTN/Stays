using UnityEngine;

/// <summary>
/// 技能使用單向物件20220423
/// </summary>

public class TreeVariation : MonoBehaviour
{
    #region 欄位
    [Header("速度")]
    public float speed=1;
    public float objectiveSpeed=2;
    [Header("原模型")]
    public GameObject original;
    [Header("枯萎模型")]
    public GameObject[] wilting;
    public bool convert = false;//改變中
    public int coldTime = 10;//設定冷卻時間

    public int cold;//實際冷卻時間
    [Header("粒子效果")]
    public ParticleSystem psSolving;
    #endregion

    private void FixedUpdate()
    {
        TreeChange();
    }
    #region
    private void TreeChange()
    {
        if (speed == objectiveSpeed&&!convert&&cold==0)//當速度等於設定目標且開關為關閉
        {
            convert = true;//開啟改變
            var completion = GameObject.Find("System").GetComponent<TaskList>();//找到任務中心
            completion.b_completion = true;//向任務中心回傳任務完成
            original.SetActive (false);//關閉初始模型
            Instantiate(wilting[0], transform);//實例化模型0在位置
            cold = 0;//計時歸零
            speed = 0;//速度還原以防多次觸發
            
        }

        if (cold == coldTime && convert)
        {
            Destroy(GameObject.Find("tree06"));//消除枯萎模型
            Instantiate(wilting[1], transform);//製造最終模型1在原點
            psSolving.Play();//完成顯示
            convert = false;//關閉改變

        }
        if (cold != coldTime&& convert) cold++;
    }

    //技能使用
    public void SkillUse(float get)
    {
        speed += get;
        //依照SkillButton傳來的速度修改20220423
    }
    #endregion
}
