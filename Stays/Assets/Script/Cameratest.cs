using UnityEngine;
/// <summary>
/// 攝影機模式切換3V
/// </summary>

public class Cameratest : MonoBehaviour
{
    #region 欄位
    [Header("目標物")]
    public Transform target;
    [Header("觸摸位置")]
    private Vector3 oneTPosition;
    [Header("與目標距離"), Range(0, 50)]
    public float dis = 20f;
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
        LS();
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
               // transform.Translate(new Vector3(Input.touches[0].deltaPosition.x * Time.deltaTime * -1, 0, 0));//攝影機位置平移(只移動X)
                transform.Translate(new Vector3(-Input.touches[0].deltaPosition.x * Time.deltaTime, -Input.touches[0].deltaPosition.y * Time.deltaTime, 0));

            }
        }
    }

    #endregion
}
