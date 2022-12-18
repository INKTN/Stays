using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// �D������
/// </summary>

public class ButtonSetting : MonoBehaviour
{
    [Header("����")]
    public string play;
    public string setting;
    public string movie;
    public string about;
    [Header("����")]
    public string URL;
    
    public void StartGame()
    {
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
}
