using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
/// <summary>
/// 主頁按紐
/// </summary>

public class ButtonSetting : MonoBehaviour
{
    [Header("首頁")]
    public string play;
    public Image black;
    public string setting;
    public string movie;
    public string about;
    [Header("關於")]
    public string URL;
    [Header("退出鍵")]
    public GameObject exitMessage;
    private GameObject sceneExit;
    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "首頁")
        {
            black.color =  Color.clear;
        }
    }
        public void StartGame()
    {
        black.color =  Color.white;
        SceneManager.LoadScene(play);
    }
    public void Movie()
    {
        SceneManager.LoadScene(movie);
    }
    public void Setting()
    {
        SceneManager.LoadScene(setting);
    }
    public void Work()
    {
        SceneManager.LoadScene(about);
    }
    public void Home()
    {
        SceneManager.LoadScene("首頁");
    }
    public void Link()
    {
        Application.OpenURL(URL);
    }
    private void Update()
    {
        //返回
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //若一秒沒有點兩次，生成提示，如果有則退出遊戲
            if (sceneExit == null)
            {
                sceneExit = Instantiate(exitMessage, FindObjectOfType<Canvas>().transform) as GameObject;
                StartCoroutine("RestQuitMessage");
            }
            else
            {

                //非首頁回首頁
                SceneManager.LoadScene("首頁");


            }
        }
    }

        #region 返回鍵
        private IEnumerator RestQuitMessage()
        {
            yield return new WaitForSeconds(1f);

            if (sceneExit != null)
            {
                Destroy(sceneExit);

            }
        }
        #endregion
    
}
