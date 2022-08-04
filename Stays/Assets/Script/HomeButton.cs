using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// ¥D­¶«ö¯Ã
/// </summary>

public class HomeButton : MonoBehaviour
{
    public string play;
    public string setting;
    public string movie;
    public string about;
   
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
        SceneManager.LoadScene("­º­¶");
    }
}
