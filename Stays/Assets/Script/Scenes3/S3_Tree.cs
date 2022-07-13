using UnityEngine;

public class S3_Tree : MonoBehaviour
{
    #region ���
    [Header("��v��")]
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
            //�Y�OĲ�I�}�l
            if (touch.phase == TouchPhase.Began)
            {
                //Ĳ�I��m��v���o�XRAY
                RaycastHit hit;
                Ray ray = oriCamera.ScreenPointToRay(pos);

                if (Physics.Raycast(ray, out hit) && hit.collider.name == "29�g�a" )
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