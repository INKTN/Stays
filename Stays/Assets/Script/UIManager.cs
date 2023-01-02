using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
/// <summary>
/// 20220416 UI��� �W��
/// 20221217 �]�w�����
/// </summary>

public class UIManager : MonoBehaviour
{
    #region ���
    [Header("�ޯ��w��")]
    public Image skill;
    //��Ҥ����
    private Image uiUse;
    public Transform touchObject;
    [Header("��ܦ�m")]
    public Vector3 onObject = new Vector3(0, 2.5f, 0);
    //�ޯ�UI�O�_���}
    public bool skillOpen = false;

    public int coldTime = 100;//�]�w�N�o�ɶ�
    private int cold;//��ڧN�o�ɶ�
    [Header("��ܨt��")]
    private DialongueSystem dialongueSystem;
    [Header("�������s�C")]
    public GameObject setting;
    public GameObject settingPage;
    public GameObject tipsPage;
    public GameObject resetPage;
    public GameObject back;
    private Cameratest cameratest;
    private Blur blurCam;
    private TouchS touchS;
    [Header("�h�X��")]
    public GameObject exitMessage;
    private GameObject sceneExit;
    

    #endregion

    private void Start()
    {
        
        setting = GameObject.Find("���d��UI");
        cameratest = GameObject.Find("MainCamera").GetComponent<Cameratest>();
        blurCam= GameObject.Find("MainCamera").GetComponent<Blur>();
        touchS= GameObject.Find("System").GetComponent<TouchS>();
        dialongueSystem = GameObject.Find("System").GetComponent<DialongueSystem>();
    }
    private void Update()
    {
        
        //��^
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //�Y�@��S���I�⦸�A�ͦ����ܡA�p�G���h�h�X�C��
            if (sceneExit == null)
            {
                sceneExit = Instantiate(exitMessage, FindObjectOfType<Canvas>().transform) as GameObject;
                StartCoroutine("RestQuitMessage");
            }
            else
            {
                
                    //�D�����^����
                SceneManager.LoadScene("����");

                
            }
        }
        //�E�J�B��ܮ���ܮɮɳ]�wUI�����
        if(!cameratest.caTask || dialongueSystem.display ||tipsPage.active||resetPage.active||settingPage.active) 
        { setting.SetActive(false); }
        else if (cameratest.caTask&& !dialongueSystem.display) setting.SetActive(true);
        if (!cameratest.caTask && !dialongueSystem.display) back.SetActive(true);
        else { back.SetActive(false); }
        //��ܮ�w��
        if (skillOpen)
        {
            if (touchObject == null)
            {
                Destroy(GameObject.Find("skill UI(Clone)"));
                skillOpen = false;
            }
        //��ܦ�m�b�I�������m
            //uiUse.transform.position = Camera.main.WorldToScreenPoint(touchObject.position+onObject);
            
            if (cold == coldTime)//��N�o�ɶ��� �R�����ϥΪ�SKILLUI
            {
                Destroy(GameObject.Find("skill UI(Clone)"));
                print("�R��UI");
                skillOpen = false;
                
            }
            else cold++;

        }
       
    }
    #region ��k

    public void SkillOn(Transform selection)
    {
        if (!skillOpen)
        {
            skillOpen = true;//SKILLOPEN���}
            touchObject = selection;//��ܪ���
                                    //��Ҥ�(�ޯ��w��,�bCanvas��m�U).��Bttion
                                    //BUG �e�����߷|�h�X�{�@��
            uiUse = Instantiate(skill, FindObjectOfType<Canvas>().transform);//��Ҥ�.GetComponent<Image>();
                                                                             //��ܦ�m�b�I�������m
                                                                             //uiUse.transform.position = Camera.main.WorldToScreenPoint(touchObject.position+onObject);
            cold = 0;//�p�ɥΨӲM��
        }
    }
    #region ���s�ϥ�
    public void Set()//�s�X�]�w����
    {
        touchS.switches = true;//��Ĳ��
        blurCam.iterations = 4;//�I���ҽk
        settingPage.SetActive(true);
    }
    public void Tip()//�s�X���ܭ���
    {
        touchS.switches = true;//��Ĳ��
        blurCam.iterations = 4;//�I���ҽk
        tipsPage.SetActive(true);
    }
    public void Re()//�s�X���]����
    {
        touchS.switches = true;//��Ĳ��
        blurCam.iterations = 4;//�I���ҽk
        resetPage.SetActive(true);
    }
    public void Back()
    {
        touchS.switches = false;//�}Ĳ��
        blurCam.iterations = 0;//���I���ҽk
        settingPage.SetActive(false);
        tipsPage.SetActive(false);
        resetPage.SetActive(false);
    }
    public void BackCa()
    {

    }
    #endregion
    #region ��^��
    private IEnumerator RestQuitMessage()
    {
        yield return new WaitForSeconds(1f);
        
        if (sceneExit != null)
        {
            Destroy(sceneExit);
            
        }
    }
    #endregion
    #endregion
}
