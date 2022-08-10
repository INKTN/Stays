using UnityEngine;
using System.Collections;
/// <summary>
/// ����@��20220810
/// </summary>
public class S1_Tower : MonoBehaviour
{
    #region ���
    [Header("��ܸ��")]
    public DataDalogue[] dataDalogues;
    [Header("��ܨt��")]
    public DialongueSystem dialongueSystem;

    [Header("Ĳ�o�ϰ�")]
    public area area;
    [Header("���Ȱ���")]
    private CityTask task;
    [Header("Ĳ���}��")]
    private TouchS t;
    [Header("��v��")]
    public Camera cameraControl;
    private Cameratest cameratest;
    public bool playdone;
    #endregion
    private void Start()
    {
        task = GameObject.Find("System").GetComponent<CityTask>();
        dialongueSystem = GameObject.Find("System").GetComponent<DialongueSystem>();
        t= GameObject.Find("System").GetComponent<TouchS>();
        cameratest = cameraControl.GetComponent<Cameratest>();
    }
    private void FixedUpdate()
    {
        Plot();
    }
    #region ��k
    private void Plot()
    {
        if (task.a_finish && !playdone && area.chIn)
        {
            dialongueSystem.StartDialogue(dataDalogues[0].conversationContent);//��ܸ��Ū��
            dialongueSystem.NameEnter(dataDalogues[0].talkName);
            playdone = true;
        }
    }
    public void StartDialogue()
    {
        if (task.a_finish && !playdone && area.chIn)
        {
            StartCoroutine(Performance());
        }
    }
    private IEnumerator Performance()
    {
        cameratest.switches = true;
        t.switches = true;
        yield return new WaitForSeconds(1);
    }
    #endregion
}
