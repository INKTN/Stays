using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialongueSystem : MonoBehaviour
{
    #region 欄位
    [Header("對話間格"), Range(0, 1)]
    public float interval = 0.1f;
    [Header("名稱輸入")]
    public Text textTito;
    [Header("畫布對話系統UI")]
    public GameObject goDialogue;
    [Header("對話系統內容")]
    public Text textContent;
    [Header("段落完成圖示")]
    public GameObject goTip;
    [Header("對話按鍵")]
    public KeyCode key = KeyCode.Mouse0;
    [Header("偵測顯示")]
    public bool display=false;
    private bool fin;//偵測說話完成
    [Header("人物顯示")]
    public GameObject certificate;
    public GameObject ramCertificate;
    #region 立繪
    [Header("年輕人(西裝)立繪")]
    public Texture2D young;
    [Header("清潔工立繪")]
    public Texture2D clear;
    [Header("售票員立繪")]
    public Texture2D ticket;
    [Header("小孩立繪")]
    public Texture2D kid;
    [Header("成年人立繪")]
    public Texture2D adult;
    [Header("奶奶立繪")]
    public Texture2D gma;
    #endregion
    [Header("觸控控制")]
    private TouchS t;
    #endregion

    void Start()
    {
        //StartCoroutine(TypeEffect());
        t = GameObject.Find("System").GetComponent<TouchS>();
    }

    /// <summary>
    /// 打字效果
    /// </summary>
    /// <returns></returns>
  private IEnumerator TypeEffect(string[] contents)
    {
        //顯示文字
        //string test1 = "test tipe";
        //string test2 = "test tipe22222";
        //string[] contents = { test1, test2 };

        goDialogue.SetActive(true);//顯示對話物件 參考項目UnityEngine.UI
        display = true;
        fin = false;

        //找到所有對話
        for (int j = 0; j < contents.Length; j++)
        {
            textContent.text = "";//清除上次對話內容
            goTip.SetActive(false);
            //for迴圈(參照 ; 參照<測試文字總字數;參照++)
            textContent.text += contents[j];//更改為疊加對話文字介面 欄位名稱.text(裡面的屬性)
            yield return new WaitForSeconds(interval); //等待(interval)秒
            /* for (int i = 0; i < contents[j].Length; i++)
            {
                //print(test[i]); 打出測試文字的第[i]個字
                textContent.text += contents[j][i];//更改為疊加對話文字介面 欄位名稱.text(裡面的屬性)
                yield return new WaitForSeconds(interval); //等待(interval)秒
            }*/

            goTip.SetActive(true);//顯示圖示
            fin = true;

            while (!Input.GetKeyDown(key))//當玩家沒有按對話按鍵時持續執行
            {
                yield return null;//等待 unll一個影格時間
            }
        }
        goDialogue.SetActive(false); //隱藏對話物件
        yield return new WaitForSeconds(interval);
        t.switches = false;//開觸控
        display = false;
    }

    /// <summary>
    /// 開始對話
    /// </summary>
    /// <param name="contents">顯示打字效果的對話內容</param>
    public void StartDialogue(string[] contents)
    {
        t.switches = true;//關觸控
        StartCoroutine(TypeEffect(contents));
    }

    /// <summary>
    /// 停止對話
    /// </summary>
    public void StopDialogue()
    {
        StopAllCoroutines();
        goDialogue.SetActive(false);
        t.switches = false;//關觸控
        display = false;
    }

    #region 顯示名稱
    private IEnumerator Nameffect(string[] contents)
    {
        //顯示文字
        //string test1 = "test tipe";
        //string test2 = "test tipe22222";
        //string[] contents = { test1, test2 };

        //找到所有對話
        for (int j = 0; j < contents.Length; j++)
        {
            textTito.text = "";//清除上次對話內容
                               //for迴圈(參照 ; 參照<測試文字總字數;參照++)

            textTito.text += contents[j];//更改為疊加對話文字介面 欄位名稱.text(裡面的屬性)
                yield return new WaitForSeconds(interval); //等待(interval)秒
            CertificatePhoto(contents[j]);
            while (!Input.GetKeyDown(key)||!fin)//當玩家沒有按對話按鍵時持續執行
            {
                yield return null;//等待 unll一個影格時間
            }
        }
      
    }
    public void NameEnter(string[] contents)
    {
        StartCoroutine(Nameffect(contents));
    }
    #endregion
    #region 角色圖
    public void CertificatePhoto(string name)
    {
       //print(name);
        if (name == "Rem")
        {
            certificate.SetActive(false);
            ramCertificate.SetActive(true);
        }
        else if (name == "年輕人")
        {
            ramCertificate.SetActive(false);
            certificate.GetComponent<RawImage>().texture = young;
            certificate.SetActive(true);
        }
        else if (name == "奶奶")
        {
            ramCertificate.SetActive(false);
            certificate.GetComponent<RawImage>().texture = gma;
            certificate.SetActive(true);
        }
        else if (name == "售票員")
        {
            ramCertificate.SetActive(false);
            certificate.GetComponent<RawImage>().texture = ticket;
            certificate.SetActive(true);
        }
        else if (name == "清潔工")
        {
            ramCertificate.SetActive(false);
            certificate.GetComponent<RawImage>().texture = clear;
            certificate.SetActive(true);
        }
        else if (name == "長大後的小孩")
        {
            ramCertificate.SetActive(false);
            certificate.GetComponent<RawImage>().texture = adult;
            certificate.SetActive(true);
        }
        else if (name == "小孩")
        {
            ramCertificate.SetActive(false);
            certificate.GetComponent<RawImage>().texture = kid;
            certificate.SetActive(true);
        }
        else
        { 
           // print("沒有角色圖");
            ramCertificate.SetActive(false);
            certificate.SetActive(false);
        }
    }
    #endregion
}
