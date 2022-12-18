using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 主頁按紐
/// </summary>

public class ButtonSetting : MonoBehaviour
{
    [Header("首頁")]
    public string play;
    public string setting;
    public string movie;
    public string about;
    [Header("關於")]
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
        SceneManager.LoadScene("首頁");
    }
    public void Link()
    {
        Application.OpenURL(URL);
    }
}
