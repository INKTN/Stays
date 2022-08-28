using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ��v���Ҧ�����3V
/// </summary>

public class Cameratest : MonoBehaviour
{
    #region ���
    [Header("�ؼЪ�")]
    public Transform target;
    //�W��������H
    private GameObject lastObj;
    public Vector3 rayLine;

    [Header("Ĳ�N��m")]
    private Vector3 oneTPosition;
    [Header("��ɽd��")]
    public float x_borderMax;
    public float x_borderMin;
    public float y_borderMax;
    public float y_borderMin;
    public float z_borderMax;
    public float z_borderMin;
    [Header("�P�ؼжZ��"), Range(0, 50)]
    public float dis = 20f;
    [Header("�F�ӫ�"), Range(0, 50)]
    public float speed = 15;
    private DialongueSystem dialongue;//��ܮذ��P�{��
    [Header("���Y�����}��")]
    public bool caTask=true;
    [Header("Ĳ���}��")]
    public bool switches;
    #endregion

    private void Start()
    {
        target = GameObject.Find("�D��").transform;//���D���ø��H�L
        transform.localPosition = Vector3.MoveTowards(transform.position, target.position, -dis);
        dialongue = GameObject.Find("System").GetComponent<DialongueSystem>();//����ܮذ��P�{��
        // cameraPosition = transform.position;
        
    }
    private void Update()
    {
        if (!dialongue.display&&!switches)//�Y�O��ܮ���ܫh��Ĳ��
        {
            LS();
            Border();
        }
        Masking();
       
    }
   
    #region ��k
    private void LS()//Long Shot
    {
        if (Input.touchCount == 1)//�p�GĲ�N�I>1
        {
            if (Input.touches[0].phase == TouchPhase.Began)
                oneTPosition = Input.touches[0].position;//�x�sĲ�N�I��m
            if (Input.touches[0].phase == TouchPhase.Moved)
            {
               // transform.Translate(new Vector3(Input.touches[0].deltaPosition.x * Time.deltaTime * -1, 0, 0));//��v����m����(�u����X)
                transform.Translate(new Vector3(-Input.touches[0].deltaPosition.x * Time.deltaTime, -Input.touches[0].deltaPosition.y * Time.deltaTime, 0));
            }
        }
    }
    private void Border()//��v�����
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, x_borderMin, x_borderMax),
            Mathf.Clamp(transform.position.y, y_borderMin, y_borderMax),
            Mathf.Clamp(transform.position.z, z_borderMin, z_borderMax));
    }
    private void Masking()//�B�׳z��
    {
        Debug.DrawLine(target.transform.position + rayLine, transform.position, Color.red);//�e�u
        RaycastHit hit;

        if (Physics.Linecast(target.transform.position + rayLine, transform.position, out hit))
        {
            if (lastObj != null)
            {
                Renderer renderer = lastObj.GetComponent<Renderer>();
                Color _color = renderer.material.color;
                _color.a = 1f;
                renderer.material.SetColor("_Color", _color);
                lastObj = null;

            }
            lastObj = hit.collider.gameObject;
            string nameTag = lastObj.tag;
            //�P�_
            if (nameTag != "MainCamera" && nameTag != "terrain")
            {
                //�ϾB�ת��ܳz��
                Renderer renderer = lastObj.GetComponent<Renderer>();
                Color _color = renderer.material.color;
                _color.a = 0.5f;
                renderer.material.SetColor("_Color", _color);
            }
        }//�٭�
        else if (lastObj != null)
        {
                Renderer renderer = lastObj.GetComponent<Renderer>();
            Color _color = renderer.material.color;
            _color.a = 1f;
            renderer.material.SetColor("_Color", _color);
            lastObj = null;
            
        }
    }

    #endregion
}
