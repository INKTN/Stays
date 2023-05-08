using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
/// <summary>
/// �D������
/// </summary>

public class ButtonSetting : MonoBehaviour
{
    [Header("����")]
    public string play;
    public Image black;
    public string setting;
    public string movie;
    public string about;
    [Header("����")]
    public string URL;
    [Header("�h�X��")]
    public GameObject exitMessage;
    private GameObject sceneExit;
    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "����")
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
        SceneManager.LoadScene("����");
    }
    public void Link()
    {
        Application.OpenURL(URL);
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
    }

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
    
}
