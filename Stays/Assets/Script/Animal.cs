using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// 動物行動
/// 20220417 添加AI行動
/// 20220418 技能使用(改為增加減少)、生物移動
/// 20220420 任務判讀
/// </summary>

public class Animal : MonoBehaviour
{
    #region 欄位
    [Header("剛體")]
    public Rigidbody RB;
    [Header("動畫")]
    public Animation AN;
    [Header("AI")]
    public NavMeshAgent agent;
    public float speed;
    [Header("預設移動位置")]
    public GameObject terget;
    private bool patrol=false;
    public Vector3[] patrolPoint;//行走位置點
    [Header("任務解決")]
    public bool solving ;
    [Header("粒子效果")]
    public ParticleSystem psSolving;
    
    #endregion
    private void Start()
    {
        RB = GetComponent<Rigidbody>();//取得剛體
        AN = GetComponent<Animation>();//取得動畫控制
        agent = GetComponent<NavMeshAgent>();//取得AI判定
        agent.SetDestination(patrolPoint[1]);//使用AI移動位置
        patrolPoint[0] = this.transform.position;//取得目前位置
        //cold = 0;
        solving = false;//任務判定重製
    }
    private void Update()
    {
        //speed = GetComponent<NavMeshAgent>().speed;//取得速度
        if(solving)TaskSolving();//任務完成
        agent.speed=speed;//設置速度
    }

    private void OnTriggerEnter(Collider other)
    {
        //預設行動
        //print("碰到" + other);
        if (other.tag == "Finish"&& !solving)
        {
            if (patrol)
            {
                agent.SetDestination(patrolPoint[1]);
                patrol = false;
            }
            else
            { 
                agent.SetDestination(patrolPoint[2]);
                patrol = true;
            }
        }
    }

    #region 方法
    //技能使用
    public void SkillUse(float get) 
    {
        speed += get;
        agent.speed = speed;
        //將AI移動速度改為GET
    }

    public void TaskSolving()
    {
        agent.SetDestination(patrolPoint[3]);//移動到終點
        psSolving.Play();//完成顯示
        if(transform.position==patrolPoint[3])speed = 0;//到達停止
    }

    #endregion

}