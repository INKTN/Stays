using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// 主角player控制
/// </summary>
public class PlayerCharacter : MonoBehaviour
{
    #region 欄位

    [Header("動畫控制")]
    private Animator an;
    [Header("偵測範圍")]
    private Vector3 detectionRange = new Vector3(0, 0, 0);
    [Range(0, 50)]
    public float detectionSize;
    [Header("偵測位置調整")]
    public Vector3 startPos;
    [Header("移動速度"), Range(0, 50)]
    public float speed;
    private NavMeshAgent agent;
    [Header("行走中")]
    public bool walking;
    [Header("目前位置")]
    public string pt;
    #endregion
    private void Start()
    {
        #region 取得相關元件
       
        an = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();//取得AI判定
        speed = agent.speed;
        #endregion
        SetStartPosition();

    }
    private void OnDrawGizmos()
    {

        Gizmos.color = new Color(1, 0, 0, .5f);//判斷區設置為藍色
        Gizmos.DrawSphere(transform.position + detectionRange, detectionSize);//偵測區位置

    }//位置偵測顯示
    private void Update()
    {
        //print(Mathf.Ceil(agent.remainingDistance));測試數值
        if (Mathf.Ceil(agent.remainingDistance) == 0)
        {
            an.SetBool("walk", false);
            agent.ResetPath();
        }//當位置==0，關閉動畫
        walking = an.GetBool("walk");
        //print(agent.hasPath);
        
    }
    #region 方法
    private void SetStartPosition()
    {
        Collider hit = Physics.OverlapSphere(transform.position + detectionRange, detectionSize)[0];
        pt = hit.name;
        transform.position = hit.transform.position + startPos;
    }//開始時矯正主角位置
    public void Move(Transform selection)
    {
        agent.speed = speed;
        SetStartPosition(); //每次觸控都校正一次
        transform.LookAt(selection.position + startPos);//看向目標
        an.SetBool("walk", true);
        agent.SetDestination(selection.position + startPos);//使用AI引導至位置

    }
    public void Location(Vector3 vector)
    {
        agent.isStopped = true;
        agent.ResetPath();
        transform.position = vector;
        //transform.LookAt(vector);//看向目標
       
        //agent.SetDestination(vector);//使用AI引導至位置
        //SetStartPosition();
    }
    #endregion
}