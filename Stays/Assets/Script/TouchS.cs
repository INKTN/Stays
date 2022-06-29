using UnityEngine;
using System;////Array.IndexOf�ϥ�
/// <summary>
/// Ĳ�I�P�w�t��
/// 20220415 �i�B�@�B���٨S���� �Ա�https://www.youtube.com/watch?v=QDldZWvNK_E
/// ��ܩ������ �f�tC#��:hightlightSelectionResponse�BISelectionResponse
/// 20220416���XUI �f�tC#��UIManager 
/// 20220429�a�����
/// </summary>

public class TouchS : MonoBehaviour
{
    #region ���
    [Header("��s�X�ޯ�ϥΪ���TAG")]
    public string[] draggingTag;
    [Header("��v��")]
    public Camera cam;
    [Header("���_�������")]
    public Material hightmaterial;
    [Header("�즳����")]
    public Material orimaterial;
    private hightlightSelectionResponse _selectionResponse;
    public Transform _salaction;
    //UI�l��
    
    private UIManager skillUI;
    private GroundJudgment ground;
    private DialongueSystem dialongue;//��ܮذ��P�{��

    [Header("�D��")]//20220620������u�ਫ�@��
    private GameObject character;
    [Range(-50, 50), Header("��l�Z��")]
    public float distance;
    #endregion
    private void Start()
    {
        skillUI = GameObject.Find("System").GetComponent<UIManager>();//���qUI������o�}��
        ground= GameObject.Find("System").GetComponent<GroundJudgment>();
        dialongue = GameObject.Find("System").GetComponent<DialongueSystem>();//����ܮذ��P�{��
        character = GameObject.Find("�D��");
    }

    void FixedUpdate()
    {
        #region �����٭�
        if (_salaction != null)
        {
            var selectionRenderer = _salaction.GetComponent<Renderer>();
            if (selectionRenderer !=null)
            {
                selectionRenderer.material = orimaterial;
            }

        }
        #endregion
        if (!dialongue.display) //�Y�O��ܮ���ܫh��Ĳ��
            RayTouch();//Ĳ�I
        
        #region Ĳ�I�������ഫ
        if (_salaction != null)
        {
            var selectionRenderer = _salaction.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material = hightmaterial;
            }

        }
        #endregion
    }
    private void RayTouch()//Ĳ�I
    {
        //�Y�OĲ���I=1
        if (Input.touchCount == 1)
        {
            //����Ĳ���T��
            Touch touch = Input.touches[0];
            Vector3 pos = touch.position;
            //�Y�OĲ�I�}�l
            if (touch.phase == TouchPhase.Began)
            {
                //Ĳ�I��m��v���o�XRAY
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(pos);
                _salaction = null;
                //if (Physics.Raycast(ray, out hit)) print(Array.IndexOf(draggingTag, hit.collider.tag));//����Ĳ�I��20220423
                if (Physics.Raycast(ray, out hit) && Array.IndexOf(draggingTag, hit.collider.tag)>-1)//Array.IndexOf(�}�C,�n�䪺��) �p�G���N�^��1�A�S���N�^��-1(20220423)�A�p�GRAY�I�쪺����TAG�����W��||���W�ٲŦX���e
                {
                    //���o�I���m������
                    var selection = hit.transform;
                    print(selection.name);
                    
                    //�o�쨺�Ӫ��󪺧����m
                    orimaterial = selection.GetComponent<Renderer>().material;
                    //print("Ĳ�I�쪫��");
                    //orimaterial = selectionRenderer.material;

                    //���褣����0���ܡA�������������w����
                    //if (selectionRenderer != null)selectionRenderer.material = hightmaterial;

                    _salaction = selection;
                    print(_salaction.name);
                    //�I�sUI����
                    skillUI.SkillOn(selection);
                }
                #region �a�O
                if (Physics.Raycast(ray, out hit) && hit.collider.tag == "ground" && !skillUI.skillOpen)//�ޯ�UI���O�}���~�ഫ�a�O
                {
                    
                        var selection = hit.transform;
                        print(selection.name+selection.position);
                        orimaterial = selection.GetComponent<Renderer>().material;
                        ground.OnGround(selection);
                        _salaction = selection;
                    
                }
                #endregion
                #region NPC
                if(Physics.Raycast(ray, out hit) && hit.collider.tag == "NPC" && !skillUI.skillOpen)
                {
                    var selection = hit.transform;
                    print(selection.name + selection.position);
                    orimaterial = selection.GetComponent<Renderer>().material;
                    //�n�bNPC�B�g�P�_��l

                    //�I�s��v����������

                    _salaction = selection;
                }
                #endregion
            }

        }    
        }
    }


