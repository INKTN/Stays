using UnityEngine;
/// <summary>
/// 主角player控制
/// </summary>
public class PlayerCharacter : MonoBehaviour
{
    #region 欄位
    [Header("剛體")]
    private Rigidbody rb;
    [Header("動畫控制")]
    private Animator an;
    [Header("偵測範圍")]
    public Vector3 detectionRange;
    [Range(0,50)]
    public float detectionSize;
    [Header("位置調整")]
    public Vector3 startPos;
    [Header("移動速度"), Range(0, 50)]
    public float speed;
    #endregion
    private void Start()
    {
        #region 取得相關元件
        rb = GetComponent<Rigidbody>();
        an = GetComponent<Animator>();
        #endregion
        SetStartPosition();

    }
    private void OnDrawGizmos()
    {
       
            Gizmos.color = new Color(1, 0, 0, .5f);//判斷區設置為藍色
            Gizmos.DrawSphere(transform.position+detectionRange,detectionSize);//偵測區位置
        
    }//位置偵測顯示
    private void Update()
    {
        
    }
    #region 方法
    private void SetStartPosition()
    {
        Collider hit = Physics.OverlapSphere(transform.position + detectionRange, detectionSize)[0];
       //print(hit.name);
        transform.position = hit.transform.position+startPos;
    }//開始時矯正主角位置
    public void Move(Transform selection)
    {
        rb.MovePosition(selection.position + startPos);
    }
    #endregion
}
