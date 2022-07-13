using UnityEngine;

public class S3_Tree : MonoBehaviour
{
    #region ���
    [Header("��v��")]
    public Camera setCamera;
    public Camera oriCamera;
    public bool ch;

    private float begainTime = 0f;//�̪��I���ɶ�
    private Vector2 startPos = Vector2.zero;//Ĳ�I�_�l�I

    public float quickDoubleTabInterval = 0.15f;
    public float lastTouchTime;//�W�@���I����}���ɶ�
    public string debugInfo = "Nothing";
    public string target;
    private static float intervals;//���j�ɶ�
    private static Touch lastTouch;//�ثe�S�Ψ�A���G�D�n�O�O���W�@����Ĳ�I
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
            //�Y�OĲ�I�}�l
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
        //print("�I�s");
        if (Time.realtimeSinceStartup - lastTouchTime < quickDoubleTabInterval)
        {
            print("if��");
            debugInfo = "touchCount";
            ch = !ch;
            setCamera.enabled = ch;
            oriCamera.enabled = !ch;
        }
    }

}