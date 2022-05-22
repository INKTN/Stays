using UnityEngine;
/// <summary>
/// 攝影機模式切換3V
/// </summary>

public class Cameratest : MonoBehaviour
{
    #region 欄位
    [Header("目標物")]
    public Transform target;
    [Header("全景/細節開關")]
    public bool detail = false;
    [Header("觸摸位置")]
    private Vector3 oneTPosition;
    [Header("與目標距離"), Range(0, 50)]
    public float dis = 20f;
    [Header("旋轉角度")]
    private float rotationEnler;
    [Header("靈敏度"), Range(0, 50)]
    public float speed = 15;
    #endregion

    private void Start()
    {
        target = GameObject.Find("主角").transform;//找到主角並跟隨他
        transform.localPosition = Vector3.MoveTowards(transform.position, target.position, -dis);
        // cameraPosition = transform.position;
    }
    private void Update()
    {
        if (detail)//相反的如果開關為T那就表示目前為特寫
        {
            MS();
        }
        else//如果細節開關是F那就表示目前為全景模式
        {
            LS();
        }
        
        //點兩次切換
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.tapCount == 2) 
            { 
                detail = !detail;
                SwitchPosition();
            }
        }
    }
    #region 方法
    private void LS()//Long Shot
    {
        if (Input.touchCount == 1)//如果觸摸點>1
        {
            if (Input.touches[0].phase == TouchPhase.Began)
                oneTPosition = Input.touches[0].position;//儲存觸摸點位置
            if (Input.touches[0].phase == TouchPhase.Moved)
            {
                transform.Translate(new Vector3(Input.touches[0].deltaPosition.x * Time.deltaTime * -1, 0, 0));//攝影機位置平移(只移動X)
            }
        }
    }
    private void MS()
    {
        if (Input.touchCount == 1)//如果觸摸點>1
        {
            if (Input.touches[0].phase == TouchPhase.Began) oneTPosition = Input.touches[0].position;//儲存觸摸位置
            if (Input.touches[0].phase == TouchPhase.Moved)//移動開始
            {
                rotationEnler = Input.touches[0].deltaPosition.x * Time.deltaTime * speed;//旋轉角度
                transform.RotateAround(target.transform.position, Vector3.up, rotationEnler);//設定攝影機旋轉(目標,軸,角度)
            }
        }
    }
    private void SwitchPosition()
    {
        if (detail) transform.localPosition = Vector3.MoveTowards(transform.position, target.position, dis);
        else transform.localPosition = Vector3.MoveTowards(transform.position, target.position, -dis);
    }
    #endregion
}
