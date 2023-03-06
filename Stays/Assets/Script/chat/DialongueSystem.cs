using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialongueSystem : MonoBehaviour
{
    #region ���
    [Header("��ܶ���"), Range(0, 1)]
    public float interval = 0.1f;
    [Header("�W�ٿ�J")]
    public Text textTito;
    [Header("�e����ܨt��UI")]
    public GameObject goDialogue;
    [Header("��ܨt�Τ��e")]
    public Text textContent;
    [Header("�q�������ϥ�")]
    public GameObject goTip;
    [Header("��ܫ���")]
    public KeyCode key = KeyCode.Mouse0;
    [Header("�������")]
    public bool display=false;
    private bool fin;//�������ܧ���
    [Header("�H�����")]
    public GameObject certificate;
    public GameObject ramCertificate;
    #region ��ø
    [Header("�~���H(���)��ø")]
    public Texture2D young;
    [Header("�M��u��ø")]
    public Texture2D clear;
    [Header("�Ⲽ����ø")]
    public Texture2D ticket;
    [Header("�p�ĥ�ø")]
    public Texture2D kid;
    [Header("���~�H��ø")]
    public Texture2D adult;
    [Header("������ø")]
    public Texture2D gma;
    #endregion
    [Header("Ĳ������")]
    private TouchS t;
    #endregion

    void Start()
    {
        //StartCoroutine(TypeEffect());
        t = GameObject.Find("System").GetComponent<TouchS>();
    }

    /// <summary>
    /// ���r�ĪG
    /// </summary>
    /// <returns></returns>
  private IEnumerator TypeEffect(string[] contents)
    {
        //��ܤ�r
        //string test1 = "test tipe";
        //string test2 = "test tipe22222";
        //string[] contents = { test1, test2 };

        goDialogue.SetActive(true);//��ܹ�ܪ��� �ѦҶ���UnityEngine.UI
        display = true;
        fin = false;

        //���Ҧ����
        for (int j = 0; j < contents.Length; j++)
        {
            textContent.text = "";//�M���W����ܤ��e
            goTip.SetActive(false);
            //for�j��(�ѷ� ; �ѷ�<���դ�r�`�r��;�ѷ�++)
            textContent.text += contents[j];//��אּ�|�[��ܤ�r���� ���W��.text(�̭����ݩ�)
            yield return new WaitForSeconds(interval); //����(interval)��
            /* for (int i = 0; i < contents[j].Length; i++)
            {
                //print(test[i]); ���X���դ�r����[i]�Ӧr
                textContent.text += contents[j][i];//��אּ�|�[��ܤ�r���� ���W��.text(�̭����ݩ�)
                yield return new WaitForSeconds(interval); //����(interval)��
            }*/

            goTip.SetActive(true);//��ܹϥ�
            fin = true;

            while (!Input.GetKeyDown(key))//���a�S������ܫ���ɫ������
            {
                yield return null;//���� unll�@�Ӽv��ɶ�
            }
        }
        goDialogue.SetActive(false); //���ù�ܪ���
        yield return new WaitForSeconds(interval);
        t.switches = false;//�}Ĳ��
        display = false;
    }

    /// <summary>
    /// �}�l���
    /// </summary>
    /// <param name="contents">��ܥ��r�ĪG����ܤ��e</param>
    public void StartDialogue(string[] contents)
    {
        t.switches = true;//��Ĳ��
        StartCoroutine(TypeEffect(contents));
    }

    /// <summary>
    /// ������
    /// </summary>
    public void StopDialogue()
    {
        StopAllCoroutines();
        goDialogue.SetActive(false);
        t.switches = false;//��Ĳ��
        display = false;
    }

    #region ��ܦW��
    private IEnumerator Nameffect(string[] contents)
    {
        //��ܤ�r
        //string test1 = "test tipe";
        //string test2 = "test tipe22222";
        //string[] contents = { test1, test2 };

        //���Ҧ����
        for (int j = 0; j < contents.Length; j++)
        {
            textTito.text = "";//�M���W����ܤ��e
                               //for�j��(�ѷ� ; �ѷ�<���դ�r�`�r��;�ѷ�++)

            textTito.text += contents[j];//��אּ�|�[��ܤ�r���� ���W��.text(�̭����ݩ�)
                yield return new WaitForSeconds(interval); //����(interval)��
            CertificatePhoto(contents[j]);
            while (!Input.GetKeyDown(key)||!fin)//���a�S������ܫ���ɫ������
            {
                yield return null;//���� unll�@�Ӽv��ɶ�
            }
        }
      
    }
    public void NameEnter(string[] contents)
    {
        StartCoroutine(Nameffect(contents));
    }
    #endregion
    #region �����
    public void CertificatePhoto(string name)
    {
       //print(name);
        if (name == "Rem")
        {
            certificate.SetActive(false);
            ramCertificate.SetActive(true);
        }
        else if (name == "�~���H")
        {
            ramCertificate.SetActive(false);
            certificate.GetComponent<RawImage>().texture = young;
            certificate.SetActive(true);
        }
        else if (name == "����")
        {
            ramCertificate.SetActive(false);
            certificate.GetComponent<RawImage>().texture = gma;
            certificate.SetActive(true);
        }
        else if (name == "�Ⲽ��")
        {
            ramCertificate.SetActive(false);
            certificate.GetComponent<RawImage>().texture = ticket;
            certificate.SetActive(true);
        }
        else if (name == "�M��u")
        {
            ramCertificate.SetActive(false);
            certificate.GetComponent<RawImage>().texture = clear;
            certificate.SetActive(true);
        }
        else if (name == "���j�᪺�p��")
        {
            ramCertificate.SetActive(false);
            certificate.GetComponent<RawImage>().texture = adult;
            certificate.SetActive(true);
        }
        else if (name == "�p��")
        {
            ramCertificate.SetActive(false);
            certificate.GetComponent<RawImage>().texture = kid;
            certificate.SetActive(true);
        }
        else
        { 
           // print("�S�������");
            ramCertificate.SetActive(false);
            certificate.SetActive(false);
        }
    }
    #endregion
}
