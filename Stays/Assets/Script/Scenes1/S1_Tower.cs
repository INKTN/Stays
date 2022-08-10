using UnityEngine;
using System.Collections;
/// <summary>
/// 鐘塔劇情20220810
/// </summary>
public class S1_Tower : MonoBehaviour
{
    #region 欄位
    [Header("對話資料")]
    public DataDalogue[] dataDalogues;
    [Header("對話系統")]
    public DialongueSystem dialongueSystem;

    [Header("觸發區域")]
    public area area;
    [Header("任務偵測")]
    private CityTask task;
    [Header("觸控開關")]
    private TouchS t;
    [Header("攝影機")]
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
    #region 方法
    private void Plot()
    {
        if (task.a_finish && !playdone && area.chIn)
        {
            dialongueSystem.StartDialogue(dataDalogues[0].conversationContent);//對話資料讀取
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
