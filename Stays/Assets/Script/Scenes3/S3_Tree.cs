using UnityEngine;

public class S3_Tree : MonoBehaviour
{
    #region 欄位
    [Header("攝影機")]
    public Camera setCamera;
    public Camera oriCamera;
    public bool ch;

    private float begainTime = 0f;//最初點擊時間
    private Vector2 startPos = Vector2.zero;//觸碰起始點

    public float quickDoubleTabInterval = 0.15f;
    public float lastTouchTime;//上一次點擊放開的時間
    public string debugInfo = "Nothing";
    public string target;
    private static float intervals;//間隔時間
    private static Touch lastTouch;//目前沒用到，不果主要是記錄上一次的觸碰
    #endregion

    private void Start()
    {
        oriCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        setCamera = GameObject.Find("TreeCa").GetComponent<Camera>();
    }
    void FixedUpdate()
    {
        TouchTree();
        //print(Input.touchCount);
   
    }
    private void TouchTree()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.touches[0];
            Vector3 pos = touch.position;
            //若是觸碰開始
            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit hit;
                Ray ray = oriCamera.ScreenPointToRay(pos);
                Physics.Raycast(ray, out hit);
                print(hit.transform.parent.gameObject.name);
                if (Physics.Raycast(ray, out hit) && hit.transform.parent.gameObject.name == target)
                {
                    startPos = touch.position;
                    begainTime = Time.realtimeSinceStartup;
                    QuickDoubleTab();
                }
            }
            if (touch.phase == TouchPhase.Ended)
            {
                intervals = Time.realtimeSinceStartup - begainTime;
                lastTouchTime = Time.realtimeSinceStartup;
                lastTouch = touch;
            }
        }
    }
     void QuickDoubleTab()
     {
        //print("呼叫");
        if (Time.realtimeSinceStartup - lastTouchTime < quickDoubleTabInterval)
        {
            print("if測");
            debugInfo = "touchCount";
            ch = !ch;
            setCamera.enabled = ch;
            oriCamera.enabled = !ch;
        }
    }

}