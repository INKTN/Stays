using UnityEngine;

public class S3_Tree : MonoBehaviour
{
    #region 欄位
    [Header("攝影機")]
    public Camera setCamera;
    public Camera oriCamera;
    public bool ch;
    
    #endregion

    private void Start()
    {
        oriCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        setCamera = GameObject.Find("TreeCa").GetComponent<Camera>();
    }
    void FixedUpdate()
    {
        TouchTree();
        print(Input.touchCount);
   
    }
    private void TouchTree()
    {
        if (Input.touchCount == 2)
        {
            Touch touch = Input.touches[0];
            Vector3 pos = touch.position;
            //若是觸碰開始
            if (touch.phase == TouchPhase.Began)
            {
                //觸碰位置攝影機發出RAY
                RaycastHit hit;
                Ray ray = oriCamera.ScreenPointToRay(pos);

                if (Physics.Raycast(ray, out hit) && hit.collider.name == "29土地" )
                {
                print(hit.collider.name);
                    ch = !ch;
                    setCamera.enabled = ch;
                    oriCamera.enabled = !ch;

                }
            }

        }
    }
            
}